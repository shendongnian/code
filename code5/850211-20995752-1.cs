    public Form1()
            {
                ipList[0] = ipa;
                ipList[1] = ipb;
    
                InitializeComponent();
                cBox1.AutoCompleteMode = AutoCompleteMode.Append;
                for(int i = 0; i < ipList.Count(); i++)
                {
                    if(ipList[i] != null)
                     cBox1.Items.Add(ipList[i].ip);
                }
            }
    
            private void cBox1_SelectionChangeCommitted(object sender, EventArgs e)
            {
                tBox1.Text = Convert.ToString(ipList[cBox1.SelectedIndex].ident);
            }
