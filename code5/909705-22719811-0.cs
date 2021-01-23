    public partial class Form1 : Form
    {       
        Startfenster fh;
        int Rohrdurchmesser, Messlanzen;
        int[,] daten; //Don't declare size yet
        public Form1(Startfenster aufrufer)
        {
            fh = aufrufer;
            InitializeComponent();                
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Rohrdurchmesser = Convert.ToInt32(fh.Controls["txbRohrdurchmesser"].Text);
            Messlanzen = Convert.ToInt32(fh.Controls["txbMesslanzen"].Text);
            daten = new int[Rohrdurchmesser, Rohrdurchmesser]; //Define size here
        }
