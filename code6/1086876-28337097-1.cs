    private void GetTable()
        {
            try
            { 
                dtemp.Rows.Add(mTable.TableID,mTable.Capacity);
            }
            catch(Exception ee)
            {                
                MessageBox.Show("Exception: " + ee.Message);
            } 
