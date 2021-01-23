     Private Sub ddlsomethinhg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsomethinhg.SelectedIndexChanged
        //ASSUME INDEX 0 IS NOT VALID VALUE
        If ddlsomethinhg.SelectedIndex = 0 Then
            Exit Sub
        Else
            //ASSUME THAT IS INTEGER
            Dim SEARCHVALUE As Integer = CInt(ddlsomethinhg.SelectedValue)
            Dim QRY As String = String.Format("select * from TABLE where colname={0}", SEARCHVALUE)
            Using cnn As New OleDbConnection("CONNECTIONSTRING")
                If cnn.State = ConnectionState.Closed Then cnn.Open()
                Using CMD As New OleDbCommand(QRY, cnn)
                    Using da As New OleDbDataAdapter(CMD)
                        Using ds As New DataSet
                            da.Fill(ds)
                            //if repeater2 is bounf in aspx page you will throw an exceptio so before you need to clean up datasource
                            Dim r As New Repeater
                            Repeater2.DataSourceID = ""
                            Repeater2.DataSource = ds.Tables(0)
                            Repeater2.DataBind()
                        End Using
                    End Using
                End Using
            End Using
        End If
    End Sub
