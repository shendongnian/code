    using System;
    using System.Windows.Forms;
    using System.Data.SQLite;
    
    namespace WindowsFormsApplication1
    {
        using System.Runtime.InteropServices;
    
    
        public partial class Form1 : Form
        {
            // This nested class must be ComVisible for the JavaScript to be able to call it.
            [ComVisible(true)]
            public class ScriptManager
            {
                // Variable to store the form of type Form1.
                private Form1 mForm;
    
                // Constructor.
                public ScriptManager(Form1 form)
                {
                    // Save the form so it can be referenced later.
                    mForm = form;
                }
    
                public void AnotherMethod(string message)
                {
                    mForm.GoToNext();
                }
            }
            public Form1()
            {
                InitializeComponent();
            }
    
            public void GoToNext()
            {
                timer1.Interval = 2000;
                timer1.Enabled = true;
            }
    
            public object MyInvokeScript(string name, params object[] args)
            {
                return webBrowser1.Document.InvokeScript(name, args);
            }
            public void SongCheck()
            {
                // Disable timer.  Enable it later if there isn't a song to play.
                if (timer1.Enabled)
                timer1.Enabled = false;
    
                // Connect to my SQLite db,
                SQLiteConnection mySQLite = new SQLiteConnection("Data Source=ytsongrequest.s3db;Version=3;");
                mySQLite.Open();
    
                // The SQLite DB consists of three columns. id, youtubeid, requestor
                // the 'id' auto increments when a row is added into the database.
                string sqlCommand = "select * from songs order by id asc limit 1";
                SQLiteCommand x = new SQLiteCommand(sqlCommand, mySQLite);
    
                SQLiteDataReader reader = x.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read())
                    {
                        // Use our custom object to call a javascript function on our webpage.
                        object o = MyInvokeScript("createPlayerAndPlayVideo", reader["youtubeid"]);
                        label2.Text = reader["requestor"].ToString();
                        // Since we've played the song, we can now remove it.
                        x = new SQLiteCommand("delete from songs where id = " + reader["id"], mySQLite);
                        x.ExecuteNonQuery();
                    }
                    mySQLite.Close();
                }
                else
                {
                    // Set a timer to check for a new song every 10 seconds.
                    timer1.Interval = 10000;
                    timer1.Enabled = true;
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.ObjectForScripting = new ScriptManager(this);
                webBrowser1.Navigate("http://localhost/testing.html");
    
                GoToNext();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                SongCheck();
            }
        }
    }
