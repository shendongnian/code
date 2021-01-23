    public partial class Form1 : Form
    {
        public Drink[] drinks;
        public const int SIZE = 5;
        private void Form1_Load( object sender, EventArgs e )
        {
            drinks = new Drink[ SIZE ];
        }
        private void picCola_Click( object sender, EventArgs e )
        {
            drinks[0].cost = 1.5;
            drinks[0].name = "";
        }
    }
