            else if (e.Row.RowType == DataControlRowType.Footer)
            {
            int i = 0;
            foreach (TableCell c in e.Row.Cells)
            {
                switch (i)
                {
                    case 0:
                        c.Text = "Totals:" + atot.ToString();
                        c.Attributes.Add("style", "text-align: right;");
                        break;
                    case 1:
                         c.Text = "Totals:" + btot.ToString();
                        c.Attributes.Add("style", "text-align: right;");
                        break;
                    case 2:
                         c.Text = "Totals:" + ctot.ToString();
                        c.Attributes.Add("style", "text-align: right;");
                        break;
                    case 3:
                        c.Text = "Totals:" + dtot.ToString();
                        c.Attributes.Add("style", "text-align: right;");
                        break;
                }
                i++;
            }
            }
