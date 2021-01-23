    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e as EventArgs) Handles btnSelect.Click
        If sender.CommandName = "MakeActiveButton" Then
            FIN = CInt(sender.CommandArgument)
            grdFIinYear.DataBind()
        End If
    End Sub
