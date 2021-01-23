        private void assignButtonValues()
        { 
            Random random = new Random();
            List<double> values = new List<Double>( new[] {0.01, 0.10, 0.50, 1, 5, 10, 50, 100, 250, 500, 750, 1000, 3000, 5000, 10000, 15000, 20000, 35000, 50000, 75000, 100000, 250000} );
            foreach (Button button in Controls.OfType<Button>())
            {
                //Is this a suitcase or just some button in the game?
                if (button.Name.Contains("Suitcase"))
                { 
                    //select random value and remove it from the list of values to ensure it's assigned to only one button
                    double buttonValue = values[random.Next(0, values.Count)];
                    values.Remove(buttonValue);
                    
                    //TODO: Your code to save the value in an array, etc, for later processing, etc.
                    //Assign corresponding picture to this button's tag
                    button.Tag = Controls.OfType<PictureBox>()
                                         .Where<PictureBox>(p => p.Tag.ToString() == buttonValue.ToString())
                                         .First<PictureBox>().Name;
                }
            }     
        }
