    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim sRol As String = Roles.GetRolesForUser.Single()
        Dim sUser As String = User.Identity.Name
        If sRol = "Phyisician" Then
            Dim searchUrl As String = "search.aspx?searchprm=" & searchTB.Text & "susrrol=1"
            Response.Redirect(searchUrl)
        End If
        If sRol = "Police" Then
            Dim searchUrl As String = "search.aspx?searchprm=" & searchTB.Text & "susrrol=2"
            Response.Redirect(searchUrl)
        End If
        Dim prm As String = Request.QueryString("searchprm").ToString
        Dim rus As String = Request.QueryString("susrrol").ToString
        If rus = 1 Then
            Dim CountResults As String
            Dim strConn1 As String = ConfigurationManager.ConnectionStrings("YourConnection").ToString
            Dim cmd1 As New SqlCommand("SEL_COUNT_Hits_Rol1", New SqlConnection(strConn1))
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Connection.Open()
            Dim sP1 As New SqlParameter("@search", SqlDbType.VarChar)
            sP1.Direction = ParameterDirection.Input
            sP1.Value = prm
            cmd1.Parameters.Add(sP1)
            CountResults = String.Format("{0:##,###.##}", cmd1.ExecuteScalar())
            cmd1.Connection.Close()
            lblHits.Text = "<i>We have found " & CountResults & " patients who match your search terms:" & "</i>"
        End If
        If rus = 2 Then
            Dim CountResults As String
            Dim strConn1 As String = ConfigurationManager.ConnectionStrings("YourConnection").ToString
            Dim cmd1 As New SqlCommand("SEL_COUNT_Hits_Rol2", New SqlConnection(strConn1))
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Connection.Open()
            Dim sP1 As New SqlParameter("@search", SqlDbType.VarChar)
            sP1.Direction = ParameterDirection.Input
            sP1.Value = prm
            cmd1.Parameters.Add(sP1)
            CountResults = String.Format("{0:##,###.##}", cmd1.ExecuteScalar())
            cmd1.Connection.Close()
            lblHits.Text = "<i>We have found " & CountResults & " patients who match your search terms:" & "</i>"
        End If
    End Sub
