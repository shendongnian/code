    public partial class Form1 : Form
    {
        private int _tickCounter = 0;
        private int _tickLimit = 500;  // set to 10 or something for the game
        private string[,] _dataArray;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _tickCounter++;
            if (_tickCounter >= _tickLimit)
            {
                // add a piece
                AddNewPieceToWell(true);
                _tickCounter = 0;
            }
            else
            {
                // Move the current pieces downward.
                for (int rowCounter = _dataArray.GetUpperBound(0); rowCounter >= 1; rowCounter--)
                {
                    for (int colCounter = 0; colCounter <= _dataArray.GetUpperBound(1); colCounter++)
                    {
                        if (_dataArray[rowCounter, colCounter] == " " && _dataArray[rowCounter - 1, colCounter] == "0")
                        {
                            _dataArray[rowCounter, colCounter] = "0";
                            _dataArray[rowCounter - 1, colCounter] = " ";
                        }
                    }
                }
            }
            DrawWell();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeWell();
            timer1.Start();
        }
        private void InitializeWell()
        {
            _dataArray = new string[,]{
                {" ", " ", "0", "0", "0", "0", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " "},
                {"0", "0", "0", "0", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " "}
            };
            DrawWell();
        }
        private void DrawWell()
        {
            rtbWell.Text = string.Empty;
            for (int rowCounter = 0; rowCounter <= _dataArray.GetUpperBound(0); rowCounter++)
            {
                for (int colCounter = 0; colCounter <= _dataArray.GetUpperBound(1); colCounter++)
                {
                    rtbWell.Text += _dataArray[rowCounter, colCounter];
                }
                rtbWell.Text += Environment.NewLine;
            }
        }
        private void AddNewPieceToWell(bool RandomPiece = true)
        {
            // ToDo
        }
    }
