      Protected Sub btnDeleteAllChecked_Click(sender As Object, e As EventArgs)
        Dim ListItems As New List(Of Integer)
        For Each el In listBaiBao.Items
            For Each item In el.Controls
                If TypeOf item Is CheckBox Then
                    If DirectCast(item, CheckBox).Checked = True Then
                        ListItems.Add(DirectCast(item, CheckBox).ToolTip)
                    End If
                End If
            Next
        Next
        'Delete record from your database 
        Using cnn As New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("YOURCONNECTIONSTRING").ToString)
            'open the connection
            If cnn.State = ConnectionState.Closed Then cnn.Open()
            'formatting your query string 
            Dim Query As String = String.Format("DELETE FROM YOURTABLENAME WHERE ID IN({0})", String.Join(",", ListItems.ToArray()))
            Using cmd As New System.Data.SqlClient.SqlCommand(Query, cnn)
                'execute delete action, update your select and rebind your list view
                Try
                    With cmd
                        .CommandType = CommandType.Text
                        'delete action
                        .ExecuteNonQuery()
                    End With
                    'ONCE DELETE HAS BEEN PERFORMED CHANGE CMD SELECT STATEMENT AD USE THE SAME COMMAND 
                    'TO REBIND A DATABASE OR A DATABLE AS YOU PREFERE LIKE HERE
                    Dim Da As New System.Data.SqlClient.SqlDataAdapter(cmd)
                    Dim Ds As New System.Data.DataSet
                    Da.Fill(Ds)
                    'REBIND CONTROL
                    listBaiBao.DataSource = Ds.Tables(0)
                    listBaiBao.DataBind()
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            End Using
        End Using
    End Sub
