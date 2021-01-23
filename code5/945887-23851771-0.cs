    Button[,] MovementPiece; //Creates the array
        private void Form1_Load(object sender, EventArgs e)
        {
            //Initializes the array
            MovementPiece = new Button[,]{ { button1, button2, button3 }, 
                                      { button4, button5, button6 },
                                      { button7, button8, button9 } };
        }
