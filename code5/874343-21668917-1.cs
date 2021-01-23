    public void GetData()
            {
                DataTable odt = new DataTable();
                odt  = obj.GetDeity();
    
                Combobox.DataSource = odt;
                .......... set other controls also...
            }
    
    public DataTable GetDeity()
            {
    
                SqlCommand cmd = new SqlCommand("get_DeityMaster");
                cmd.CommandType = CommandType.StoredProcedure;
                return getdatatable(cmd); // YOUR DATA FETCHING LOGIC
            }
