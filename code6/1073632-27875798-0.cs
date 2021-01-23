    public DataTable GetData(string SelectQuery)
    {
        using(var da = new SqlDataAdapter(SelectQuery,xconn))
        {
            DataTable xdata = new DataTable();
            da.Fill(xdata);
            return xdata;
        }
    }
