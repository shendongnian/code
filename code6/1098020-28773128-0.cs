    if (GridView1.Rows[e.NewEditIndex].BackColor != Color.SeaGreen &&
                    GridView1.Rows[e.NewEditIndex].BackColor != Color.IndianRed)
            {
                e.Cancel = true;
                errorLabel.Text = "Please scan roll before updating QtyRun";
            }
            else
            {
                //do something else
            }
