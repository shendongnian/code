     public ObservableCollection<YourType> ReadInvoices()
     {
            Connect();  //write connection
            YourCollection.Clear();  //this is a private data part
            MySqlCommand cmd = new MySqlCommand(write your query);
            MySqlDataReader dr = cmd.ExecuteReader();
            YourCollection.Clear();
            YourType item = new YourType();
            while (dr.Read()){
              item.column = dr.GetInt32("columnName"); //or any other type
              YourCollection.Add(item);
            }
            dr.Close();
            Disconnect();
    return YourCollection;
    }
