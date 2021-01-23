    public partial class SelectSize : Form
        {
            MainWin f1;
            public SelectSize(MainWin f1)
            {
                this.f1 = f1;
                InitializeComponent();
            }
    
            public String Name
            { get; set; }
    
            private void button1_Click(object sender, EventArgs e)
            {
                
                if (((int.Parse(noRows.Text) % 2) == 0) && (((int.Parse(noCols.Text) % 2) == 0)) && ((int.Parse(noRows.Text) ==
                    int.Parse(noCols.Text))) && ((int.Parse(noRows.Text) > 6) && ((int.Parse(noRows.Text) > 6))))
                {
                    //String name = this.Name;
                    PlayMe f = new PlayMe(int.Parse(noCols.Text), int.Parse(noCols.Text), f1.Name);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
