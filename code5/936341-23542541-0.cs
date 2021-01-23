      class Class1
       {
           static String str = "your connection string";
          static MySqlConnection con = null;
        public static DataSet getTable()
        {
            //MySqlDataReader Object
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                //We will need to SELECT all or some columns in the table
                //via this command
                String cmdText = "SELECT * FROM adat";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                
    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
          DataSet  ds = new DataSet();
            da.Fill(ds, "R");
            con.Close();
            return ds;
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close(); //close the connection
                }
            }
        }
    }
}
        public MainWindow()
      {
      InitializeComponent();
       UpdateGrid();
      } 
     public void UpdateGrid()
    {
       dataGrid1.DataMember = "R";
            dataGrid1.DataSource = class1.gettable();
    }
