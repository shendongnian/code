    foreach (TableRow tr in left.Rows)
        {
            foreach (TableCell tc in tr.Cells)
            {
                foreach (Control ctrl in tc.Controls)
                {
                    CheckBox chk = ctrl as CheckBox;
                    if (chk != null)
                    {
                        if (chk.Checked)
                        {
                            string id = chk.ID;//Checkbox id
                            string text = chk.Text;//Checkbox Text
                            YourSaveMethodHere();
                        }
                    }
                }
                
            }
        }
