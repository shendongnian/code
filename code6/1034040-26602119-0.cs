        public DataRow FetchNext()
    {
        DataRow drow = dt.NewRow();
        if (dr.Read() && dr.HasRows)  //this will loop through rows unless cancel is clicked
        {
            try
            {
                for (int i = 0; i < listCols.Count; i++)
                {
                    drow[(DataColumn)listCols[i]] = dr[i];
                }
                dt.ImportRow(drow);
                totalRowCount++;
                this.isChanged();
                return drow;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        else
        {
            
            return drow;
        }
    }
