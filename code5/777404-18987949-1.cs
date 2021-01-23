          else if (e.Row.RowType == DataControlRowType.Footer)
    {
        try
        {
        e.Row.Cells[0].Text = "Totals:" + atot.ToString();
        e.Row.Cells[0].Attributes.Add("style", "text-align: right;");
        }
        catch
        {
        }
        try
        {
        e.Row.Cells[1].Text = "Totals:" + btot.ToString();
        e.Row.Cells[1].Attributes.Add("style", "text-align: right;");
        }
        catch
        {
        }
        try
        {
        e.Row.Cells[2].Text = "Totals:" + ctot.ToString();
        e.Row.Cells[2].Attributes.Add("style", "text-align: right;");
        }
        catch
        {
        }
        try
        {
        e.Row.Cells[3].Text = "Totals:" + dtot.ToString();
        e.Row.Cells[3].Attributes.Add("style", "text-align: right;");
        }
        catch
        {
        }
    }
