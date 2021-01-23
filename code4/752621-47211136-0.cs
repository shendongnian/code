        public void MyFunction()
        {
            groupBox1.AutoSize = true;
            // Do stuff (e.g., add controls to GroupBox)...
            // Once all controls have been added to the GroupBox...
            groupBox1.AutoSize = false;
            
            // Add optional padding here if desired.
            groupBox1.Height = myBottomMostControl.Bottom;
        }
