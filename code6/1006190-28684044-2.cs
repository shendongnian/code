    <System.Web.Services.WebMethod(EnableSession:=True)> Public Shared Sub PokePage()
            CheckUser(CheckMode.CheckAndWriteExpireTimeInDB)
        End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            CheckUser()
    End Sub
