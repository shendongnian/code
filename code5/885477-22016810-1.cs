          public partial class Schedule : PhoneApplicationPage
         {      
    List<teams> teamsList;
     List<appendList> _appendList;
    // the local folder DB path
    string DB_PATH = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sample.sqlite");
    //SQLite connection
    private SQLiteConnection dbConn;
    dbConn = new SQLiteConnection(DB_PATH);
        /// Create the table Task, if it doesn't exist.
        dbConn.CreateTable<teams>();
       teamsList = dbConn.Query<teams>("select * from teams").ToList<teams>();
          //
          _appendList=new List<appendList>();
         foreach(var t in teamsList)
        {
          _appendList.add(new appendList
           {
              teamImage="/..your local image Path/"+t.team_name+".png";
           });
        }
       // Bind source to listbox
       scheduleListbox.ItemsSource =_appendList;
    }
