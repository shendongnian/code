     <System.Runtime.CompilerServices.Extension()> _
        Public Sub DownloadFile(browser As IE, fileUrl As String, savePath As String)
    
            Using wc As New WebClient
                Dim cookies As String = browser.Eval("document.cookie")
                If Not String.IsNullOrEmpty(cookies) Then
                    wc.Headers.Add(HttpRequestHeader.Cookie, cookies)
                End If
    
                wc.DownloadFile(fileUrl, savePath)
            End Using
        End Sub
