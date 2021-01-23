    List<NumericUpDown> numberControls = new List<NumericUpDown>();
    
    //Method to Create NumericUpDown
    private void AddNewNumrical(int numiraclNew)
    {
    
        for (int x = 0; x < numiraclNew; x++)
        {
            NumericUpDown numiNumber = new NumericUpDown();
            xCoor = coor.Next(0, 700);
            yCoor = coor.Next(0, 710);
            numiNumber.Location = new Point(xCoor, yCoor);
      
            numiNumber.Size = new System.Drawing.Size(50, 15);
            numiNumber.Maximum = 1000;
            numiNumber.Minimum = 1;
            numberControls.Add(numiNumber); //Save the control off for later
            this.pnlNodes.Controls.Add(numiNumber);
        }
    }
