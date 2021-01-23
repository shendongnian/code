    Option Strict On
    Option Explicit On
    Imports System.Net
    Imports System.IO
    Imports System.Linq
    Imports System.Threading
    Imports System.Web
    Imports System.Web.UI.WebControls
    Imports Google
    Imports Google.Apis.Auth.OAuth2
    Imports Google.Apis.Auth.OAuth2.Flows
    Imports Google.Apis.Auth.OAuth2.Web
    Imports Google.Apis.Services
    'for drive
    Imports Google.Apis.Drive.v2
    Imports Google.Apis.Drive.v2.Data
    Imports Google.Apis.Util.Store
    'for AuthorizationCodeRequestUrl
    Imports Google.Apis.Auth.OAuth2.Requests
    Imports System.Drawing
    Public Class _Default
        Inherits Page
    
        Private redirect_uri As String = ""
        Private client_id As String = ""
        Private client_secret As String = ""
        Private service As DriveService
    
        'Application logic should manage users authentication. 
        'This sample works with only one user. You can change it by retrieving
        'data from the session.
        'You use the word user because you are authorized by the user to access
        'their drive contents.
    Private UserId As String = "user" 
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim SCOPES As String() = New [String]() {"https://www.googleapis.com/auth/drive", "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/drive.install"}
        Dim flow As GoogleAuthorizationCodeFlow
        'use extended class to create google authorization code flow
        'use custom own datastore
        flow = New ForceOfflineGoogleAuthorizationCodeFlow(New GoogleAuthorizationCodeFlow.Initializer() With {
        .DataStore = New FileDataStore("D:\inetpub\wwwroot\go\filedatastore", True),
        .ClientSecrets = New ClientSecrets() With {
            .ClientId = client_id,
            .ClientSecret = client_secret
        },
        .Scopes = SCOPES
    })
        Dim uri = Request.Url.ToString()
        Dim redirecturi As String = redirect_uri
        Dim code = Request("code")
        If code IsNot Nothing Then
            output.Text &= "<br />Code: " & code & "<br />"
            output.Text &= "<br />UserID: " & UserId & "<br />"
            output.Text &= "<br />URI: " & uri & "<br />"
            output.Text &= "<br />RedirectURI: " & redirecturi & "<br />"
            output.Text &= "<br />uri-substring-thing: " & uri.Substring(0, uri.IndexOf("?")) & "<br />"
            Dim token = flow.ExchangeCodeForTokenAsync(UserId, code, redirecturi, CancellationToken.None).Result
            ' Extract the right state.
            Dim oauthState = AuthWebUtility.ExtracRedirectFromState(flow.DataStore, UserId, Request("state")).Result
            Response.Redirect(oauthState)
        Else
            Dim result = New AuthorizationCodeWebApp(flow, redirecturi, uri).AuthorizeAsync(UserId, CancellationToken.None).Result
            If result.RedirectUri IsNot Nothing Then
                ' Redirect the user to the authorization server.
                Response.Redirect(result.RedirectUri)
            Else
                ' The data store contains the user credential, so the user has been already authenticated.
                service = New DriveService(New BaseClientService.Initializer() With {
                .HttpClientInitializer = result.Credential,
                .ApplicationName = "Drive API Sample"
            })
            End If
        End If
    End Sub
    ''' <summary>
    ''' Download a file
    ''' Documentation: https://developers.google.com/drive/v2/reference/files/get
    ''' </summary>
    ''' <param name="_service">a Valid authenticated DriveService</param>
    ''' <param name="_fileResource">File resource of the file to download</param>
    ''' <param name="_saveTo">location of where to save the file including the file name to save it as.</param>
    ''' <returns></returns>
    Public Shared Function downloadFile(_service As DriveService, _fileResource As Data.File, _saveTo As String) As [Boolean]
        If Not [String].IsNullOrEmpty(_fileResource.DownloadUrl) Then
            Try
                Dim x = _service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl)
                Dim arrBytes As Byte() = x.Result
                System.IO.File.WriteAllBytes(_saveTo, arrBytes)
                Return True
            Catch e As Exception
                Console.WriteLine("An error occurred: " + e.Message)
                Return False
            End Try
        Else
            ' The file doesn't have any content stored on Drive.
            Return False
        End If
    End Function
    Public Async Function GetFile(IncomingFileID As String) As Tasks.Task
        Try
            Dim request As FilesResource.GetRequest = service.Files.Get(IncomingFileID)
            Dim response As Data.File = Await request.ExecuteAsync(CancellationToken.None)
            downloadFile(service, response, "D:/inetpub/wwwroot/go/" & Guid.NewGuid.ToString)
        Catch ex As Exception
            Dim str As String = "<br />" & ex.ToString()
            str = str.Replace(Environment.NewLine, Environment.NewLine + "<br/>")
            str = str.Replace("  ", " &nbsp;")
            output.Text &= String.Format("<font color=""red"">{0}</font>", str)
        End Try
    End Function
    '''<summary>Gets the File Lists of the user.</summary>
    Public Async Function FetchFilelists() As System.Threading.Tasks.Task
        Try
            ' Get all files of the user asynchronously.
            Dim request As FilesResource.ListRequest = service.Files.List()
            'get only my files
            request.Q = "mimeType contains 'image/'"
            Dim response As FileList = Await request.ExecuteAsync()
            ShowFilelists(response)
        Catch ex As Exception
            Dim str = ex.ToString()
            str = str.Replace(Environment.NewLine, Environment.NewLine + "<br/>")
            str = str.Replace("  ", " &nbsp;")
            output.Text = String.Format("<font color=""red"">{0}</font>", str)
        End Try
    End Function
    Private Sub ShowFilelists(response As FileList)
        If response.Items Is Nothing Then
            output.Text &= "You have no files!<br/>"
            Return
        End If
        output.Text &= "Showing files...<br/>"
        Dim ctr As Integer = 0
        For Each file As Google.Apis.Drive.v2.Data.File In response.Items
            ctr += 1
            Dim listPanel As New Panel() With {
                .BorderWidth = Unit.Pixel(1),
                .BorderColor = Color.Black
            }
            listPanel.Controls.Add(New Label() With {
                .Text = file.Title + "--" + file.MimeType
                    })
            listPanel.Controls.Add(New Label() With {
                .Text = "<hr/>"
                })
            If file.MimeType.ToString().Contains("folder") = False Then
                listPanel.Controls.Add(New HyperLink() With {
                .Text = "Download",
                .NavigateUrl = file.WebContentLink
            })
                listPanel.Controls.Add(New Button() With {
                                       .Text = "Use This Image", .OnClientClick = "document.getElementById('currentImageId').value = '" & file.Id & "';return false;"})
            End If
            lists.Controls.Add(listPanel)
        Next
        output.Text &= "Total Files: " & ctr.ToString
    End Sub
    Protected Async Sub listButton_Click(sender As Object, e As EventArgs) Handles listbutton.Click
        Await FetchFilelists()
    End Sub
    Protected Async Sub DownloadImageButton_Click(sender As Object, e As EventArgs) Handles DownloadImageButton.Click
        Dim idToUse As String = Page.Request.Form(currentImageId.UniqueID)
        output.Text &= "<br />Attempting to download id: " & idToUse & "<br />"
        Await GetFile(idToUse)
        output.Text &= "<br />Download Completed<br />"
    End Sub
    'overwrite. force offline.
    Friend Class ForceOfflineGoogleAuthorizationCodeFlow
        Inherits GoogleAuthorizationCodeFlow
        'source: //gotoanswer.stanford.edu/google_analytics_oauth_with_accesstype__offline_in_c-4478263/
        Public Sub New(initializer As GoogleAuthorizationCodeFlow.Initializer)
            MyBase.New(initializer)
        End Sub
        Public Overrides Function CreateAuthorizationCodeRequest(redirectUri As String) As AuthorizationCodeRequestUrl
            Dim ss = New Google.Apis.Auth.OAuth2.Requests.GoogleAuthorizationCodeRequestUrl(New Uri(AuthorizationServerUrl))
            ss.AccessType = "offline"
            ss.ApprovalPrompt = "force"
            ss.ClientId = ClientSecrets.ClientId
            ss.Scope = String.Join(" ", Scopes)
            ss.RedirectUri = redirectUri
            Return ss
        End Function
    End Class
    End Class
