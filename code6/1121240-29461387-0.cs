    using SQLite;
    // ...
    
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Message { get; set; }
    }
    
    // Create our connection
    string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
    var db = new SQLiteConnection (System.IO.Path.Combine (folder, "notes.db"));
    db.CreateTable<Note>();
    
    // Insert note into the database
    var note = new Note { Message = "Test Note" };
    db.Insert (note);
