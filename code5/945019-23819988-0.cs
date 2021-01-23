    public partial class Form1 : Form
    {
        Button[,] MovementPiece;  //Declare at the class level
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MovementPiece = new Button[,]{ { button1, button2, button3 }, 
                              { button4, button5, button6 },
                              { button7, button8, button9 }
                            }; //Initialized in your Form Load event
            // Do your button initialization here
        }
    }
