    Protected Sub dlImages_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlImages.ItemCommand
                If e.CommandName = "ImageClick" Then
                    Session("ImageName") = e.CommandArgument
                    Response.Redirect("ScreenDetails.aspx")
                End If
            End Sub
 
