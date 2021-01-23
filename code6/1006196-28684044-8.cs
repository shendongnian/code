    <System.Web.Services.WebMethod(EnableSession:=True)> Public Shared Sub PokePage()
            CheckSession()
        End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            CheckSession()
    End Sub
