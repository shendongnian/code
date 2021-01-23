        private int numStates = 5;
        private void Form1_Load(object sender, EventArgs e)
        {            
            int yLocation = 0;
            System.Windows.Forms.TextBox[] textBoxes = new System.Windows.Forms.TextBox[numStates];
            for (int index = 0; index < textBoxes.Length; index++)
            {
                textBoxes[index] = new System.Windows.Forms.TextBox();
                textBoxes[index].Location = new System.Drawing.Point(126, yLocation);
                textBoxes[index].Name = "stateName" + index;
                textBoxes[index].Size = new System.Drawing.Size(161, 20);
                textBoxes[index].AcceptsTab = true;
                textBoxes[index].TabStop = false;
                textBoxes[index].TabIndex = index;
                textBoxes[index].KeyPress += Form1_KeyPress; //Added line
                this.Controls.Add(textBoxes[index]);
                textBoxes[0].Focus();                
                yLocation += 25;                
            }            
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\t')
            {
                int currentState = int.Parse(((Control)sender).Name.Replace("stateName", ""));
                if(currentState == numStates - 1)
                {
                    this.Controls["stateName" + (0).ToString()].Focus();
                }
                else
                {
                    this.Controls["stateName" + (currentState + 1).ToString()].Focus();
                }
            }
        }
