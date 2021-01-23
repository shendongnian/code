     Protected Sub btnGetValues_Click(sender As Object, e As EventArgs) Handles btnGetValues.Click
        Dim xdoc As XDocument = XDocument.Load(Server.MapPath("~/data.xml"))
        Dim ns As XNamespace = "http://winscp.net/schema/session/1.0"
        Dim Sb As New StringBuilder
        Try
            'iterate within xmlelement where assume with this code that "session" is root
            'and descendant are upload and its child and touch with its childs
            For Each el In (From a In xdoc.Root.Descendants(ns + "upload") Select a)
                For Each subelement In el.Descendants
                    Response.Write("<b>" & subelement.Name.ToString & "</b><ul>")
                    If subelement.HasAttributes Then
                        For Each att In subelement.Attributes
                            Response.Write("<li>" & att.Name.ToString & ":" & att.Value.ToString & "</li>")
                        Next
                    End If
                    Response.Write("</ul>")
                Next
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
       
    End Sub
