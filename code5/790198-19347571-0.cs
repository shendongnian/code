    public class YourClass
    {
         SQLiteDataAdapter dataAdp2;
         SQLiteCommandBuilder cmdBuilder;
         .....
         public void BindMyGrid()
         {
              sqlitecon.Open();
              string Query2 = "Select * from Security_details "; 
              SQLiteCommand createCommand2 = new SQLiteCommand(Query2, sqlitecon);                
              
              dataAdp2 = new SQLiteDataAdapter(createCommand2);
              cmdBuilder = new SQLiteCommandBuilder(dataAdp2);
              DataTable dt2 = new DataTable("Security_details");
              dataAdp2.Fill(dt2);
              datagrid_security.ItemsSource = dt2.DefaultView;
              sqlitecon.Close();
         }
         ....
         public void SubmitData()
         {
              dataAdp2.Update((datagrid_security.ItemsSource As DataView).Table);
         }
         ......
    }
