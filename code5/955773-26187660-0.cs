    if (!ValidateParametersExistInScript(rtxtQuery.Text))
    {
        GridViewCellInfo cell = rgvNewParameters.Rows[0].Cells["ParameterName"];
        cell.Style.CustomizeFill = true;
        cell.Style.BackColor = Color.Red;
        cell.Style.DrawFill = true;
        MessageBox.Show("Parameters do not match definition inside query, " + 
                        "please check spelling and try again.");
    }
