    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.OleDb;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            // Use this connection string if your database has the extension .accdb
            private const String access7ConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\inetpub\wwwroot\app_data\WordsDB.accdb";
            // Data components
            private OleDbConnection myConnection;
            private DataTable myDataTable;
            private OleDbDataAdapter myAdapter;
            private OleDbCommandBuilder myCommandBuilder;
            // Index of the current record
            private int currentRecord = 0;
            private void MainForm_Load(object sender, EventArgs e)
            {
                String command = "SELECT * FROM Words";
                try
                {
                    myConnection = new OleDbConnection(access7ConnectionString);
                    myAdapter = new OleDbDataAdapter(access7ConnectionString, myConnection);
                    myCommandBuilder = new OleDbCommandBuilder(myAdapter);
                    myDataTable = new DataTable();
                    FillDataTable(command);
                    /* Move this "DisplayRow(currentRecord);" down below and use 
                       after you get a random number to pick a random word as shown
                       below... */
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    // =========== Get a Random Number first, then call DisplayRow() ===============
                // Figure out the upper range of numbers to choose from the rows returned
                int maxCount = myDataTable.Rows.Count;
                // generate a random number to use for "rowIndex" in your 'myDataTable.Rows[rowIndex]'
                Random randomNR = new Random();
                int myRndNR = randomNR.Next(0, maxCount - 1);
                // Execute your DisplayRow(int rowIndex) using myRndNR
                DisplayRow(myRndNR);
    // ===========
            }
            private void FillDataTable(String selectCommand)
            {
                try
                {
                    myConnection.Open();
                    myAdapter.SelectCommand.CommandText = selectCommand;
                    // Fill the DataTable with the rows returned by the select command
                    myAdapter.Fill(myDataTable);
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in FillDataTable : \r\n" + ex.Message);
                }
            }
            private void DisplayRow(int rowIndex)
            {
                // Check that we can retrieve the given row
                if (myDataTable.Rows.Count == 0)
                    return; // nothing to display
                if (rowIndex >= myDataTable.Rows.Count)
                    return; // the index is out of range
                // If we get this far then we can retrieve the data
                try
                {
                    DataRow row = myDataTable.Rows[rowIndex];
                    WordsLbl.Text = row["SpellingWords"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in DisplayRow : \r\n" + ex.Message);
                }
            }
            public Form1()
            {
                InitializeComponent();
            }
        }
    }
