    //looping for boundfield
        for (int i = GridViewApproval.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GridViewApproval.Rows[i];
                GridViewRow previousRow = GridViewApproval.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count & j != 5; j++)
                {
                    if (row.Cells[j].Text == previousRow.Cells[j].Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }
                            row.Cells[j].Visible = false;
                        }
                    }
                }
            }
            //Looping for TemplateField
            for (int i = GridViewApproval.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GridViewApproval.Rows[i];
                GridViewRow previousRow = GridViewApproval.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count - 1; j++)
                {
                    //Define what index on your template field cell that contain same value
                    if (((LinkButton)row.Cells[9].FindControl("linkAction")).Text == ((LinkButton)previousRow.Cells[9].FindControl("linkAction")).Text)
                    {
                        if (previousRow.Cells[9].RowSpan == 0)
                        {
                            if (row.Cells[9].RowSpan == 0)
                            {
                                previousRow.Cells[9].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[9].RowSpan = row.Cells[9].RowSpan + 1;
                            }
                            row.Cells[9].Visible = false;
                        }
                    }
                }
            }
            //This is to redefine again.
            for (int count = 0; count < GridViewApproval.Rows.Count; count++)
            {
                LinkButton lblprojectTest = GridViewApproval.Rows[count].Cells[9].FindControl("linkAction") as LinkButton;
                lblprojectTest.Text = "Details";
            }
