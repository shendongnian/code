        Protected Sub GridView1_buttonsclicked(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Delete" Then
            'Delete clicked with index of " + e.CommandArgument.ToString
            'Your code here, using the e.commandargument as the gridview index, then select column values using that index.
        End If
    End Sub
