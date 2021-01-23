                ' save ke server
                Dim wb As XLWorkbook = New XLWorkbook
                wb.Worksheets.Add(datatable01, "sheetdata")
                wb.SaveAs(strPath)
                ' save ke local folder
                Dim response As System.Web.HttpResponse = System.Web.HttpContext.Current.Response
                response.ClearContent()
                response.Clear()
                response.ContentType = "text/plain"
                response.AddHeader("Content-Disposition", "attachment; filename=" & rptName & ".xlsx" + ";")
                response.TransmitFile(strPath)
                response.Flush()
                response.End()
