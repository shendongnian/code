         string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\ZIP.DBF;Extended Properties=dBase IV";
         OleDbConnection conn = new OleDbConnection ( conString );
         command = conn . CreateCommand ( );
 
         // create the DataSet
         DataSet ds = new DataSet ( );
         dataGridView1 . DataSource = null;
 
         // open the connection
         conn . Open ( );
         string commandString = "Select * from  ZIP.DBF";
         // run the query
         command . CommandText = commandString;
         OleDbDataAdapter adapter = new OleDbDataAdapter ( command );
         adapter . Fill ( ds );
 
         // close the connection
         conn . Close ( );
 
         // set the grid's data source
         dataGridView1 . DataSource = ds . Tables [ 0 ];
         }
     catch ( Exception ex)
         {
         MessageBox . Show (  ex . Message );
 
         }      
