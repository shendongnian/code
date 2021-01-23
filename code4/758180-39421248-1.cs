            protected void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectButton = (RadioButton)sender;
            GridViewRow row = (GridViewRow)selectButton.Parent.Parent;
            int a = row.RowIndex;
            foreach (GridViewRow rw in gvCursos.Rows)
            {
                if (selectButton.Checked)
                {
                    
                    if (rw.RowIndex != a)
                    {
                        lbResultado.Text = rw.RowIndex.ToString();
                        RadioButton rd = rw.FindControl("rbtnSelect") as RadioButton;
                        rd.Checked = false;
                    }
                }
            }
        }
