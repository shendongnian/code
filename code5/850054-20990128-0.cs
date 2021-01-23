        public partial class AddProject : Form
        {
            public AddProject()
            {
                InitializeComponent();
            }
        
            private void btn_addproject_Click(object sender, EventArgs e)
            {            
               if(string.isNullOrEmpty(textBox_project_name.Text) ||
               string.isNullOrEmpty(comboBox1_project_status.Text) ||
               string.isNullOrEmpty(dateTimePicker1.Text))
              {  
                  errorLabel.Text = "Enter text in all fields";
                  return;
              } 
              else
              {
                  errorLabel.Text = "";                 
              }
              
              string constr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:/Users   /Xprts_3/Documents/Database1.accdb";
              string cmdstr = "insert into tb1(name,rollno,projectdate)   (@First,@Last,@pdate)";
             
              OleDbConnection con = new OleDbConnection(constr);
              OleDbCommand com = new OleDbCommand(cmdstr, con);
              con.Open();
    
              com.Parameters.AddWithValue("@First", textBox_project_name.Text);
              com.Parameters.AddWithValue("@Last", comboBox1_project_status.Text);
              com.Parameters.AddWithValue("@pdate", dateTimePicker1.Text);
              com.ExecuteNonQuery();
              con.Close();        
           }
    }
