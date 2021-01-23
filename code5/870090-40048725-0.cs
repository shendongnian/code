           Protected Sub lvParent_ItemDataBound(sender As Object, e As
        ListViewItemEventArgs)
                Dim dtChild As DataTable
                 dtChild = Child_SEL(New Guid(lvParent.DataKeys(e.Item.DataItemIndex)("ID").ToString()))
                 Dim lvChild As ListView = TryCast(e.Item.FindControl("lvChild"), ListView)
                 lvChild.DataSource = dtChild
                 lvChild.DataBind()
             End Sub
    
     
    
        Public Function Child_SEL(ParentID As Object) As DataTable
                Dim conn As SqlConnection = New SqlConnection(ConnectionString)
                Dim cmd As SqlCommand = conn.CreateCommand()
                Dim dt As DataTable = Nothing
                Dim ds As New DataSet
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Child_SEL" 
    Dim param_ParentID As SqlParameter = cmd.Parameters.Add("@ParentID ", SqlDbType.UniqueIdentifier)
                param_ParentID.Value = ParentID
                Try
                    conn.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(ds, "x")
                    dt = ds.Tables("x")
                Catch e As Exception
                    Error_INS(Today, Page.ToString, MethodBase.GetCurrentMethod().Name.ToString(), e.Message.ToString)
                    HttpContext.Current.Response.Redirect("~/Secure/Error.aspx")
                Finally
                    conn.Close()
                End Try
                Return dt
            End Function
    
        'Stored Procedure Code
        ALTER PROC [dbo].[Child_SEL]
        @ParentID UNIQUEIDENTIFIER                    
        AS
        BEGIN
        SELECT Bla,Bla,Bla
        FROM Child WHERE ParentID = @ParentID 
        END
