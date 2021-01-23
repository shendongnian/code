    private ObservableCollection<string> items = new ObservableCollection<string>();
    public ObservableCollection<string> Items
    {
        get { return items; }
        set { items = value; NotifyPropertyChanged("Items"); }
    }
...  
    void getAllItems()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT  DISTINCT item_name FROM items", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            String items = dr.GetString(0);
            Items.Add(items);
        }
        conn.Close();
    }
