      using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        using System.Data.OleDb;
        
        namespace WindowsFormsApplication5
        {
            public partial class Form1 : Form
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lumi\\Desktop\\Test_DataB.accdb");
                OleDbDataAdapter ad = new OleDbDataAdapter();
                DataSet ds = new DataSet();
        
        
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void indexBindingNavigatorSaveItem_Click(object sender, EventArgs e)
                {
                    this.Validate();
                    this.indexBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.test_DataBDataSet);
        
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
                    // TODO: This line of code loads data into the 'test_DataBDataSet.Index' table. You can move, or remove it, as needed.
                    this.indexTableAdapter.Fill(this.test_DataBDataSet.Index);
        
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    try
                    {
                  
                   con.Open();  
        
                        SqlCeCommand insert_command = new SqlCeCommand("Luna_nasterii,Nume,Prenume,Nr_fisa) " + "VALUES (@Luna_nasterii, @Nume, @Prenume, @Nr_fisa)", con);
        
                        insert_command.Parameters.AddWithValue("@Luna_nasterii", OleDbType.Numeric).Value = int.Parse(textBox1.Text);
                        insert_command.Parameters.AddWithValue("@Nume",OleDbType.VarChar).Value = textBox2.Text.ToString();
                        insert_command.Parameters.AddWithValue("@Prenume",  OleDbType.VarChar).Value = textBox3.Text.ToString();
                        insert_command.Parameters.AddWithValue("@Nr_fisa",  OleDbType.Numeric).Value = int.Parse(textBox4.Text);
                     
        
                        create_adapt.InsertCommand = insert_command;
                        insert_command.ExecuteNonQuery();
                        con.close();
                    }
        
        
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
        
        
                }
            }
        }
