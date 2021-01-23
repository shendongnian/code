    private void UpdateListBox()
    {
       List<string> myList=new List<string();
       listBox2.DataSource=null; //Clear existing binding;
       string query="Select FieldName,FieldValue from Mytable";
        int x=100; //Max padding
        using(OleDbCommand cmd = new OleDbCommand(query, Myconn))
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();              
                    while (readerr.Read())
                    {
                       myList.Add(reader[0].ToString()+":" + "€"PadLeft(x-reader[0].ToString().Length) + reader[1].ToString());      
                    }
                }
    listBox2.Datasource=myList; 
    }
