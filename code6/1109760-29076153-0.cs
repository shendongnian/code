        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        namespace ValuesPassingFromformtoform
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
               
                private void button1_Click(object sender, EventArgs e)
                {
                    string f_name = first_name.Text;
                    string L_name = last_name.Text;
                    string user_email = email.Text;
                    string pass = password.Text;
                    string depart = department.SelectedItem.ToString();
                    string gender = "";
        
        
                    Form2 f2 = new Form2(f_name,L_name,user_email,pass,depart);            
                    f2.Show();
                }
            }
        }
    
    and Form2.cs is
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ValuesPassingFromformtoform
    {
        public partial class Form2 : Form
        {
            public Form2(string f_name, string L_name, string user_email, string pass, string depart)
            {
                InitializeComponent();
                textBox2.Text = f_name;
    
            }
           
        }
    }
