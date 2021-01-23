        private void timer1_Tick(object sender, EventArgs e) //Timer to update textbox
        {
            if (tempDisplayBox.Text != globalVar.updateTemp) //Only update if temperature is different
            {
                try
                {
                    tempDisplayBox.AppendText(Environment.NewLine);
                    tempDisplayBox.AppendText(globalVar.updateTemp);
                }
                catch (NullReferenceException)
                { 
                }
            }
        }
