    Protected Sub MyPointsRepeater_RowCommand(sender As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles MyPointRepeater.ItemCommand
         
            arg = e.CommandArgument.ToString().Split(";"c)
    
    
        End Sub
