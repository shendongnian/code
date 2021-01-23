       System.Windows.Forms.Form frm = new Form();
        TextBox txt = new TextBox();
        Button inputset = new Button();
        String VartoSet;
        public void Main()
        {
            inputset.Text = "Enter Period to Query On";
            inputset.Width = 200;
            inputset.Height = 100;
            //VartoSet = "User::QMonth";
            inputset.Click += new EventHandler(inputset_Click);
            txt.Name = "Input";
            frm.Controls.Add(txt);
            frm.Controls.Add(inputset);
            frm.ShowDialog();
            MessageBox.Show( Dts.Variables["User::QMonth"].Value.ToString());
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        void inputset_Click(object sender, EventArgs e)
        {
            Dts.Variables["User::QMonth"].Value = Convert.ToInt32(txt.Text);
            frm.Close();
        }
