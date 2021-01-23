    using System; 
    using System.Collections.Generic; 
    using System.ComponentModel; 
    using System.Data; 
    using System.Drawing; 
    using  System.Linq; 
    using System.Text; 
    using System.Windows.Forms; 
    using    System.Data.OleDb; 
    using System.Text.RegularExpressions;
       
    namespace Login 
    {    
    
       public partial class Register : Form    
       {
       
       
       
    
       public Register()
       {
           
           InitializeComponent();
       }
    
       private void button1_Click(object sender, EventArgs e)
       {
           try
           {
               if(text1Box1.Text == "" || textBox2.Text == "")
               {
                    MessageBox.Show("Mandatory fields password or user is empty");
                    retrun; //I'm not sure if this return is need. Remove it if MessageBox "breaks" the execution of the code below.
               }
               OleDbCommand cmd = new OleDbCommand(@"Select * from Data where User=@User");
               cmd.Parameters.AddWithValue("@User", textBox1.Text);
              
               DataSet dst = SqlManager.GetDataSet(cmd, "Data");
               
               if(dst.Tables[0].Rows > 0)
               {
                   MessageBox.Show("User already exist");
                   return; //again i'm not sure that this return is needed.
               }
                              
               Insert("Data", "User", textBox1.Text, "Pass", textBox2.Text);         
                
               textBox1.Text = null;
               textBox2.Text = null;
               MessageBox.Show("Registration Success!");
               this.Hide();
    
               Form1 frm = new Form1();
               frm.Show();
                                
           }  
           catch (Exception ex)
           {   
               MessageBox.Show(ex.Message);  
           }
       }
