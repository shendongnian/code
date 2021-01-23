    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        users = Membership.GetAllUsers()
    
        If Not IsPostBack Then
            UserName.DataSource = users
            UserName.DataBind()
        End If
    End Sub
