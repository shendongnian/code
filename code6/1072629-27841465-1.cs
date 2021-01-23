         using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Data;
            using System.Drawing;
            using System.Text;
            using System.Windows.Forms;
            using System.IO;
            using System.Data.OleDb;
        
        
        
        namespace WindowsApplication4
        {    
    public partial class Form1 : Form
        {
            private string mDirectory; // this will hold the directory path you are working on
            private string[] mFiles; // this will hold all files in the selected directory
            public Form1()
            {
                InitializeComponent();
            }
    
            //OPEN PROGRAM
            private void Form1_Load(object sender, EventArgs e)
            {
                this.richTextBox1.Text = "Waiting for commands...";
                this.toolStripStatusLabel1.Text = "Waiting for commands...";
            }
    
            // FIND FILES BUTTON CLICK
            private void button1_Click(object sender, EventArgs e)
            {
                this.richTextBox1.Text = "Looking for files...";
                GetFiles();
            }
    
            // function to read files at source
            private void GetFiles()
            {
                mDirectory = @"C:\Users\74-des\Desktop\"; // better to use OpenFolderDialog to choose the directory
                mFiles = System.IO.Directory.GetFiles(mDirectory, "*.DBF");
    
                if (mFiles.Length > 0)
                {
                    try
                    {
                        foreach (string filename in mFiles)
                        {
    
                            this.richTextBox1.Text = string.Join(Environment.NewLine, mFiles);
                            string filenameWithoutPath = System.IO.Path.GetFileName(filename);
                        }
                    }
    
                    catch (SystemException excpt)
                    {
                        this.richTextBox1.Text = excpt.Message;
                    }
                }
            }
    
            private void ReadData()
            {
                this.toolStripStatusLabel1.Text = "Preparing To Read Data";
                this.Refresh();
                string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=dBase IV", mDirectory);
    
                try
                {
                    foreach (var file in mFiles)
                    {
                        string queryString = string.Format("SELECT * FROM " + "{0}.DBF", System.IO.Path.GetFileNameWithoutExtension(file));
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            OleDbCommand command = new OleDbCommand(queryString, connection);
                            connection.Open();
                            OleDbDataReader reader = command.ExecuteReader();
    
                            while (reader.Read())
                            {
                                if (reader.IsDBNull(1))
                                {
                                    this.richTextBox1.Text = "Null";
                                }
                                else
                                {
                                    string DATE = reader.GetValue(0).ToString();
                                    string TIME = reader.GetValue(1).ToString();
                                    string CODE = reader.GetValue(2).ToString();
                                    string item = reader.GetValue(3).ToString();
    
                                    this.richTextBox1.Text = DATE + TIME + "   " + CODE + " " + item;
                                    this.Refresh();
                                }
                            }
                            reader.Close();
                            connection.Close();
                        }
                    }
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(mDirectory))
                    MessageBox.Show("You should Get Files first!");
                else
                    ReadData();
            }
        }
    }
