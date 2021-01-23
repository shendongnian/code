        string pass;
        string name;
        bool when = false;
        public Form1()
        {
            InitializeComponent();
        }
        List<string> users = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void regBtn_Click(object sender, EventArgs e)
        {
            if (regTxtBoxName.TextLength < 4)
            {
                when = true;
                     if (regTxtBoxPass.TextLength < 4)
                     {
                         {
                             if (when == false)
                             {
                                 progBar1.Value = 0;
                                 MessageBox.Show("Choose password/name with minimal length 5", "Registration ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             }
                             }
                         regTxtBoxPass.BackColor = Color.Red;
                     }
                     else
                     {
                         if (when == false)
                         {
                             progBar1.Value = 0;
                             MessageBox.Show("Choose password/name with minimal length 5", "Registration ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                         regTxtBoxPass.BackColor = Color.White;
                     }
                     regTxtBoxName.BackColor = Color.Red;
                     progBar1.Value = 0;
                     MessageBox.Show("Choose password/name with minimal length 5", "Registration ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                regTxtBoxName.BackColor = Color.White;
                if (regTxtBoxPass.TextLength < 4)
                {
                        regTxtBoxPass.BackColor = Color.Red;
                        progBar1.Value = 0;
                        MessageBox.Show("Choose password/name with minimal length 5", "Registration ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    regAge.Minimum = 0;
                    regAge.Maximum = 150;
                    if (regAge.Value >= 15)
                    {
                        if(chkBox1.Checked){
                        regTxtBoxName.BackColor = Color.White;
                        regTxtBoxPass.BackColor = Color.White;
                        regAge.BackColor = Color.White;
                        pass = regTxtBoxPass.Text;
                        name = regTxtBoxName.Text;
                        users.Add(name);
                        txtBoxUsers.Text += Environment.NewLine + name;
                        regTxtBoxPass.Text = "";
                        regTxtBoxName.Text = "";
                        regAge.Value = 0;
                        progBar1.Value = 100;
                        MessageBox.Show("Your account has been succesfully created.", "Registration FINSIHED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        }
                        else{MessageBox.Show("Please, accept condition terms.", "Accept it omg....",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        progBar1.Value = 0;
                        };
                    }
                    else
                    {
                        regAge.BackColor = Color.Red;
                        regAge.Value = 0;
                        progBar1.Value = 0;
                        MessageBox.Show("You're too young for this :)", "Registration ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        public void logBtn_Click(object sender, EventArgs e)
        {
            if (logTxtBoxName.Text == name)
            {
                if (logTxtBoxPass.Text == pass)
                {
                    progBar1.Value = 100;
                    MessageBox.Show("You have beeon successfully logged in.", "Logged IN", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    progBar1.Value = 0;
                    MessageBox.Show("Your username or password is wrong!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                progBar1.Value = 0;
                MessageBox.Show("Your username or password is wrong!","Login failed", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
  
            }
`
