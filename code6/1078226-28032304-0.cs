    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private List<Button> buttons = new List<Button>();
        
        public Form1()
        {
            InitializeComponent();
            buttons.Add(ao);
            buttons.Add(eo);
            buttons.Add(dd);
            buttons.Add(go);
            buttons.Add(eeo);
        }
        private void A_Click(object sender, EventArgs e)
        {
            int y = rnd.Next(buttons.Count);
            for (int i = 0; i < buttons.Count; i++ )
            {
                buttons[i].Visible = (i == y);
            }
        }
    }
