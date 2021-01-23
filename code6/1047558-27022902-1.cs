            int numStates = 5;
            int yLocation = 0;
            System.Windows.Forms.TextBox[] textBoxes = new System.Windows.Forms.TextBox[numStates];
            for (int index = 0; index < textBoxes.Length; index++)
            {
                textBoxes[index] = new System.Windows.Forms.TextBox();
                textBoxes[index].Location = new System.Drawing.Point(126, yLocation);
                textBoxes[index].Name = "stateName" + index;
                textBoxes[index].Size = new System.Drawing.Size(161, 20);               
                textBoxes[index].TabStop = true;
                textBoxes[index].TabIndex = index;
                this.Controls.Add(textBoxes[index]);
                textBoxes[0].Focus();
                yLocation += 25;                
            }
