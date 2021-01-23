          ----- code behind page ----
    Imports System
    Imports Telerik.Web.UI
    Imports System.Web
    Imports System.Web.Services
    Imports WebService1
    Partial Class _Default
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Dim ws As New WebService1
                rad.DataSource = ws.HelloWorld
                rad.DataTextField = "text"
                rad.DataValueField = "val"
                rad.DataBind()
            End If
        End Sub
        Protected Sub rad_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles rad.SelectedIndexChanged
        End Sub
        Protected Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click
            rad.Enabled = False
        End Sub
        <WebMethod()> _
        Public Shared Function isDuplicate() As String
            Return "Hello text"
        End Function
    End Class
