    int currentXposition, currentYposition;
    const string positionLabel = "Current Position: ";
    private void Test_Load(object sender, EventArgs a)
    {
        var temp=Color.Transparent;    //Used to store the old color name of the panels before mouse events
        var colorName = Color.Red;      //Color used to highlight panel when mouse over
        int numBlocks = 8;             //Used to hold the number of blocks per row
        int blockSize=70;
        //Initialize new array of Panels  new
        string[,] Position = new string[8, 8];
        ChessPanel[,] chessBoardPanels = new ChessPanel[numBlocks, numBlocks];
        string Alphabet = "A,B,C,D,E,F,G,H";
        string Numbers ="1,2,3,4,5,6,7,8";
        string[] alphaStrings = Alphabet.Split(',');
        string[] numStrings=Numbers.Split(',');
        int FirstValue, SecondValue;
        //Store Position Values --- no idea what this is supposed to do...
        for (int firstValue = 0; firstValue < 8; ++firstValue)
        {
            FirstValue = Alphabet[firstValue];
            for (int SecValue = 0; SecValue < 8; ++SecValue)
            {
                SecondValue = Numbers[SecValue];
                Position[firstValue, SecValue] = alphaStrings[firstValue] + numStrings[SecValue];
            }
        }
        //Loop to create panels
        for (int iRow = 0; iRow < numBlocks; iRow++)
        {
            for (int iColumn = 0; iColumn < numBlocks; iColumn++)
            {
                ChessPanel p = new ChessPanel();
                //set size
                p.Size = new Size(blockSize, blockSize);
                //set back colour
                p.BackColor = (iRow + (iColumn % 2)) % 2 == 0 ? Color.Black : Color.White;
                //set location
                p.Location = new Point(blockSize *iRow+15, blockSize * iColumn+15);
                
                p.MouseEnter += (s,e) =>
                {
                    var cpSelf = s as ChessPanel;
                    if (cpSelf != null)
                    {
                    	label1.Text = Position[cpSelf.iRow, cpSelf.iColumn];
                    }
                };
                
                groupBox1.Controls.Add(p);
                chessBoardPanels[iRow, iColumn] = p;
            }
        }
    }
