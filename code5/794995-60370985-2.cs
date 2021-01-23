csharp
using System.Data.SQLite;
    private void btnInsert_Click(object sender, RoutedEventArgs e)
    {
     string connection = @"Data Source=C:\Folder\SampleDB.db;Version=3;New=False;Compress=True;";
     SQLiteConnection sqlite_conn = new SQLiteConnection(connection);
     string stringQuery ="INSERT INTO _StudyInfo"+"(Param,Val)"+"Values('Name','" + snbox.Text + "')";//insert the studyinfo into Db
     sqlite_conn.Open();//Open the SqliteConnection
     var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
     SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
     SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
     SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
     sqlite_conn.Close();//Close the SqliteConnection
    }
