    using System;
    using System.Data.SqlServerCe;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Data;
    
    namespace app
    {
        class Connexion
        {
            SqlCeConnection conn;
            string connectionString;
            string chemin;
            public Connexion(string path,string password)
            {
                this.chemin = path;
                connectionString = string.Format("DataSource={0}", this.chemin + ";Password="+password);
                conn = new SqlCeConnection(connectionString); 
            }
    
            public bool isConnected() 
            {
                try
                {
                    conn.Open();
                }catch(SqlCeException e){
                    MessageBox.Show(e.ToString());
                    return false;
                }
                bool temp = false;
                SqlCeDataReader dr;
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM tableProduit";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    temp = true;
                }
                else
                {
                    temp = false;
                }
                dr.Close();
                conn.Close();
                return temp;
            }
    
            public void writeData(string filepath,string filetype)
            {
                conn.Open();
                SqlCeDataReader dr;
                SqlCeCommand cmd = new SqlCeCommand();
                SqlCeDataAdapter adpt = new SqlCeDataAdapter();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM tableProduit";
                dr = cmd.ExecuteReader();
                adpt.SelectCommand = cmd;
                if (filetype == "txt")
                {
                    TextWriter writer = new StreamWriter(filepath);
                    while (dr.Read())
                    {
                        writer.WriteLine(dr["codeBarre"] + ":" + dr["qte"]);
                    }
                    writer.Close();
                }
                else
                {
                    //Create the data set and table
                    DataSet ds = new DataSet("New_DataSet");
                    DataTable dt = new DataTable("New_DataTable");
    
                    //Set the locale for each
                    ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                    dt.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                    adpt.Fill(dt);
                    ds.Tables.Add(dt);
                }
                dr.Close();
                conn.Close();
            }
        }
    }
