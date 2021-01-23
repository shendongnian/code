    Private Sub GridView1_DataBound(sender As Object, e As EventArgs) Handles GridView1.DataBound
        // Add checks for row count.
        // create a new row
        Dim gvr As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim gvc As TableCell
        // Create a new empty cell
        gvc = New TableCell()
        //add a new TextBox to the cell
        gvc.Controls.Add(New TextBox())
        // Add the cell to the row
        gvr.Cells.Add(gvc)
        // repeat above as necessary
        // Add row to Gridview at index 1 (0 is bound header)
        // GridView1.Controls(0) is the Gridview table
        GridView1.Controls(0).Controls.AddAt(1, gvr)
