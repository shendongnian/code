    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient; 
     
    namespace DBsync2
    {
          //table2 is the Master(with duplicates) Table and table1 is the one without duplicates 
    
    <pre>
    public partial class Form1 : Form
    {
        private MySqlConnection conn1 = null;
        private MySqlConnection conn2 = null;
        string cs1,cs2;
     
        class IdTsEntry
        {
            public Int64 fid { get; set; }
            public String fdate { get; set; }
        }
     
        void Init()
        {
            //initialize cs1, cs2 to suit the database connection details.
    
            try
            {
                string servername1 = server1.ToString();
                string uname1 = uid1.ToString();
                string pass1 = pwd1.ToString();
                string dbName1 = dbname1.ToString();
     
                string tbl1 = table1.ToString();
                string tbl2 = table2.ToString();
     
                conn1 = new MySqlConnection(cs1);
                conn1.Open();
                conn2 = new MySqlConnection(cs2);
                conn2.Open();
     
                tbl1 = "abc";
                tbl2 = "def";
     
                // Load target list's ids and timestamps
                string stmt1 = "SELECT seriennummer, DATE_FORMAT(fdate, '%Y-%M-%D %H:%i:%s') FROM " + tbl1;
                MySqlCommand cmd1 = new MySqlCommand(stmt1, conn1);
                List&lt;IdTsEntry&gt; A = new List&lt;IdTsEntry&gt;();
                using (MySqlDataReader reader = cmd1.ExecuteReader())
                {
                    //while (reader.Read())
                    //{ // I assume the fields are set to NOT NULL
                    //    A.Add(new IdTsEntry()
                    //    {
                    //        fid = reader.GetInt64(0),
                    //        fdate = reader.GetString(1)
                    //    });
                    //}
    
                    while (reader.Read())
                    { // I assume the fields are set to NOT NULL
                        A.Add(new IdTsEntry()
                        {
                            fid = reader.IsDBNull(0) ? -1L : reader.GetInt64(0),
                            fdate = reader.IsDBNull(1) ? "" : reader.GetString(1)
                        });
                    }
                }
                // Load source list's ids and timestamps
                string stmt2 = "SELECT fid, DATE_FORMAT(fdate, '%Y-%M-%D %H:%i:%s') FROM " + tbl2;
                MySqlCommand cmd2 = new MySqlCommand(stmt2, conn2);
     
                List&lt;IdTsEntry&gt; B = new List&lt;IdTsEntry&gt;();
                using (MySqlDataReader reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    { // I assume the fields are set to NOT NULL
                        B.Add(new IdTsEntry()
                        {
                            fid = reader.GetInt64(0),
                            fdate = reader.GetString(1)
                        });
                    }
     
                }
     
                // Filter lists
                List&lt;Int64&gt; List1 = new List&lt;Int64&gt;();
                List&lt;Int64&gt; List2 = new List&lt;Int64&gt;();
                foreach (IdTsEntry b in B)
                {
                    var a = A.FirstOrDefault(e =&gt; e.fid.Equals(b.fid));
                    if (a == null) 
                        List2.Add(b.fid); // b.id not in A -&amp;gt; new row
                    else if (!a.fdate.Equals(b.fdate))
                        List1.Add(b.fid); // b.id in A but other timestamp -&amp;gt; altered row
                }
     
                            // Update altered rows
                //string ct1 = "SELECT variante,charge,DATE_FORMAT(fdate, '%Y-%M-%D %H:%i:%s') FROM " + tbl2 + " WHERE fid = {0}";
                //string ct2 = "UPDATE " + tbl1 + " SET variante = @val1,charge = @val2, fdate = @val3 WHERE seriennummer = {0}";
                foreach (Int64 id in List1)
                {
                    // Read all entry values into parameters
                   // cmd1.CommandText = String.Format(ct1, id);
                    cmd1.CommandText = "SELECT variante,charge,DATE_FORMAT(fdate, '%Y-%M-%D %H:%i:%s') FROM " + tbl2 + " WHERE fid = " + id.ToString();
     
                   // MessageBox.Show(cmd1.CommandText);
                    cmd2.Parameters.Clear();
                    int i = 0;
                    using (MySqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (!reader.Read()) continue; 
                        for (int n = 0; n &lt; reader.FieldCount; n++)
                        {
                            cmd2.Parameters.AddWithValue(String.Format("val{0}", ++i),
                                reader.IsDBNull(n) ? DBNull.Value : reader.GetValue(n));
                        }
     
                    }
                    // Update row
                    //cmd2.CommandText = String.Format(ct2, id);
                    cmd2.CommandText = "UPDATE " + tbl1 + " SET variante = @val1,charge = @val2, fdate = @val3 WHERE seriennummer = " + id.ToString();
                    cmd2.ExecuteNonQuery();
                }
     
                                // Insert new rows
                //ct1 = "SELECT fid, variante,charge,DATE_FORMAT(fdate, '%Y-%M-%D %H:%i:%s') FROM " + tbl2 + " WHERE fid = {0}";
                //ct2 = "INSERT INTO " + tbl1 + " (seriennummer, variante,charge,fdate) " +
                //    "VALUES (@val1, @val2, @val3, @val4)";
                //    cmd2.CommandText = ct2;
                    cmd2.CommandText = "INSERT INTO " + tbl1 + " (seriennummer,variante,charge,fdate) " +
                        "VALUES (@val1, @val2, @val3, @val4)";
                    foreach (Int64 id in List2)
                    {
                        // Read all values into parameters
                        //cmd1.CommandText = String.Format(ct1, id);
    
                        cmd1.CommandText = "SELECT fid,variante,charge,DATE_FORMAT(fdate, '%Y-%M-%D %H:%i:%s') FROM " + tbl2 + " WHERE fid = " + id.ToString();
                        cmd2.Parameters.Clear();
                        int i = 0;
                        using (MySqlDataReader reader = cmd1.ExecuteReader())
                        {
                            if (!reader.Read()) continue;
                            for (int n = 0; n &lt; reader.FieldCount; n++)
                            {
                                cmd2.Parameters.AddWithValue(String.Format("val{0}", ++i),
                                    reader.IsDBNull(n) ? DBNull.Value : reader.GetValue(n));
                            }
                        }
                        // Insert row
                        cmd2.ExecuteNonQuery();
                    }
     
            }
     
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
     
            }
     
        }
        public Form1()
        {
            InitializeComponent();
     
            Init();
     
        }
     
    }
    
    
    }
