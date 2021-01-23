            Public Shared Sub ExportDataSetToExcel(ByVal ds As DataTable, ByVal filename As String)
            Dim response As HttpResponse = HttpContext.Current.Response
            response.Clear()
            response.Buffer = True
            response.Charset = ""
            response.ContentType = "application/vnd.ms-excel"
                Using sw As New StringWriter()
                Using htw As New HtmlTextWriter(sw)
                    Dim dg As New DataGrid()
                    dg.DataSource = ds
                    dg.DataBind()
                    dg.RenderControl(htw)
                    response.Charset = "UTF-8"
                    response.ContentEncoding = System.Text.Encoding.UTF8
                    response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble())
                    response.Output.Write(sw.ToString())
                    response.[End]()
                End Using
            End Using
        End Sub
