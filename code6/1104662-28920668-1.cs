    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (System.Web.UI.WebControls.TableRow row in tblSubstantialOwners.Rows)
            {
                if (row.GetType() == typeof(TableRow))
                {
                    for (int count = 0; count < row.Cells.Count; count++)
                    {
                        TableCell cell = row.Cells[count];
                        datarow[count] = cell.Controls.OfType<TextBox>().FirstOrDefault().Text;
                    }
                }
            }
        }
