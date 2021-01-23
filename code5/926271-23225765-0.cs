    protected void calcAvg(object sender, CommandEventArgs e)
    {
        int row = Convert.ToInt32(e.CommandArgument.ToString()) - 1;
        DataListItem ActiveRow = dlMeasurements.Items[row];
    // Snipped code doing stuff with current row
    // Compare how many rows completed to number of rows requested
    if (!(row + 1 == Convert.ToInt32(txtSample.Text)))
    {
        // Create new row
        DataRow drNew = nextMeas.Tables[0].NewRow();
        nextMeas.Tables[0].Rows.Add(drNew);
        // Change item index and rebind
        dlMeasurements.EditItemIndex = row + 1;
        dlMeasurements.DataSource = nextMeas.Tables[0];
        dlMeasurements.DataBind();
        //Set focus with the Script Manager
        smInspection.SetFocus((TextBox)(dlMeasurements.Items[row + 1].FindControl("txtRead1")));
    }
    else
    {
        // Otherwise close the measurements and show exit button
        dlMeasurements.EditItemIndex = -1;
        dlMeasurements.DataSource = nextMeas.Tables[0];
        dlMeasurements.DataBind();
        btnSaveAndPrint.Visible = true;
    }
    }
    }
