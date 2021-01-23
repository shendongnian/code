    private void radGridView1_ViewCellFormatting(object sender, CellFormattingEventArgs e)
    {
        if (e.CellElement is GridHeaderCellElement)
        {
            if (e.CellElement.Text == "Your header cell text") //checking for the text in header cell
            {
                e.CellElement.DrawBorder = true;
                e.CellElement.DrawFill = true;
                e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.CellElement.BackColor = Color.Green;
                e.CellElement.ForeColor = Color.Red;
            }
        }
    }
