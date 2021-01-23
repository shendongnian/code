            foreach (DataGridViewRow item in GV.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    //here you get the rowcell value :
                    string val = item.Cells[1].Value.ToString();
                    //If you want to convert to a textbox :
                    TextBox textBox = (TextBox)item.Cells[1].Value;
            }
