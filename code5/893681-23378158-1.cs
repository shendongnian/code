       Public Sub BulkInserTest(ByVal list As System.Collections.IEnumerable)
        Dim hasElement = False
        For Each el In list
            hasElement = True
            Exit For
        Next
        If hasElement = True Then
            Dim dt As DataTable = EQToDataTable(list)
            Using cnn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("BUCLCNN").ConnectionString)
                cnn.Open()
                Using tr As SqlClient.SqlTransaction = cnn.BeginTransaction
                    Using sqlbulk As New SqlClient.SqlBulkCopy(cnn, SqlBulkCopyOptions.KeepIdentity, tr)
                        With sqlbulk
                            .DestinationTableName = "Ads"
                            .BatchSize = 2500
                            For Each el As DataColumn In dt.Columns
                                If el.ColumnName = "IDAds" Or el.ColumnName = "Province" Or el.ColumnName = "SubCategory" Or el.ColumnName = "AdsComments" Or el.ColumnName = "CarDetails" Or el.ColumnName = "HomeDetails" Or el.ColumnName = "Images" Or el.ColumnName = "Customer" Then
                                    //not execute
                                Else
                                    Dim map As New SqlBulkCopyColumnMapping(el.ColumnName, el.ColumnName)
                                    .ColumnMappings.Add(map)
                                End If
                            Next
                            Try
                                If dt.Rows.Count > 0 Then
                                    .WriteToServer(dt)
                                    tr.Commit()
                                End If
                            Catch ex As Exception
                                tr.Rollback()
                                Dim lg As New EADSCORE.Helpers.CustomLogger(False)
                                lg.WriteLog(ex)
                            End Try
                        End With
                    End Using
                End Using
                Dim cmd As New SqlCommand("Update Ads Set Article=replace(Article,'&amp;','&');Update Ads Set Title=replace(Article,'&amp;','&')", cnn)
                cmd.ExecuteNonQuery()
            End Using
        End If
    End Sub
    
