        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gvStandard.AllowPaging = False
        gvStandard.DataBind()
        For i As Integer = 0 To gvStandard.Rows.Count - 1
            Dim row As GridViewRow = gvStandard.Rows(i)
            For Each cell As TableCell In row.Cells
                If cell.HasControls() = True Then
                    If cell.Controls(0).[GetType]().ToString() = "System.Web.UI.WebControls.CheckBox" Then
                        Dim chk As CheckBox = DirectCast(cell.Controls(0), CheckBox)
                        If chk.Checked Then
                            cell.Text = "True"
                        Else
                            cell.Text = "False"
                        End If
                    End If
                End If
            Next
        Next
        gvStandard.HeaderRow.Style.Add("background-color", "#FFFFFF")
        gvStandard.RenderControl(hw)
        Response.Output.Write(sw)
        Response.Flush()
        Response.End()
    End Sub
