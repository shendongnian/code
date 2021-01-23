    public MainForm mainForm {get;set;}
    
    public  FormB(MainForm mainForm)
    {
      this.mainForm= mainForm;
    
    }
            private void buttonOpenFormA_Click(object sender, EventArgs e)
            {
                formA displayformA = new formA(this);
                displayformA.Show();
    
                this.Hide();
            }
                 private void buttonOpenFormB_Click(object sender, EventArgs e)
                {
                    formB displayformB = new formB(this.mainForm);
                    displayformB.Show();
    
                    this.Hide();
                }
            private void buttonGoBack_Click(object sender, EventArgs e)
            {
                (this.mainform as MainForm).Show();
                 this.Close();
            }
