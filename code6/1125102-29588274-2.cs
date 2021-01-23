    public partial class Players : Form
    {
        public List<TextBox> spelers;
        public Form1 game = new Form1();
        public Players()
        {
            InitializeComponent();
            spelers = new List<TextBox>()
            { 
               inputSpeler1, inputSpeler2, inputSpeler3,
               inputSpeler4, inputSpeler5, inputSpeler6
            }
        }
    
        private void btnSpelers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(spelers
                      .Where(x => !string.IsNullOrWitheSpace(x.Text))
                      .Count().ToString());
            game.ShowDialog();
        }
    }
