    string RowFilter = string.Empty;
    CreateOrAppendToFilter(cb11, ref RowFilter);
    CreateOrAppendToFilter(cb16, ref RowFilter);
    CreateOrAppendToFilter(cb31, ref RowFilter);
      if(RowFilter.Length > 0) 
      {
         try
            {
                //Check an see what's in the dgv
                DataView dv = new DataView(dt);
                dv.RowFilter = RowFilter;
                datagridview1.DataSource = dv;
            }
            catch (Exception)
            {
                MessageBox.Show("Can’t find the column", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
      }
        private void CreateOrAppendToFilter(CheckBox cb, ref string RowFilter) 
        { 
            if(RowFilter.Length>0) 
            {
                RowFilter += " OR ";
            }
            RowFilter += (cb.Checked) ? string.Format("[AreaCode] = {0}", cb.Text.Trim()) : string.Empty ;
        }
