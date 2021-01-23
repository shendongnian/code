            string rowFilter = string.Empty;
            if (cb11.Checked)
            {
                rowFilter += " [AreaCode] = " + cb11.Text.Trim();
            }
            if (cb16.Checked)
            {
                // I use 14 for the length check because " [AreaCode] = " is 14 characters in length.
                if (rowFilter.Length > 14)
                    rowFilter += " AND";
                rowFilter += " [AreaCode] = " + cb16.Text.Trim();
            }
            if (cb31.Checked)
            {
                if (rowFilter.Length > 14)
                    rowFilter += " AND";
                rowFilter += " [AreaCode] = " + cb31.Text.Trim();
            }
            
            try
            {
                //Check an see what's in the dgv
                DataView dv = new DataView(dt);
                dv.RowFilter = rowFilter;
                datagridview1.DataSource = dv;
            }
            catch (Exception)
            {
                MessageBox.Show("Can’t find the column", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
