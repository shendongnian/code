        private int choice(int min,int max)
        {
            Random ran = new Random();
            return ran.Next(min,max);
        }
        private void button1_Click(object sender, EventArgs e)
        {
 
            int number = choice(1, 3);
            if (number == 1)
            {
            //Computer selects rock
                if (rockRadioButton.IsChecked==true)
                {
                    MessageBox.Show("Rock vs Rock. Tie!");
                }
                else if(paperRadioButton.IsChecked==true)
                {
                    MessageBox.Show("Paper vs Rock. You win!");
                }
                else if(scissorsRadioButton.IsChecked==true)
                {
                    MessageBox.Show("Scissors vs Rock. You lose!");
                }
            }
            else if (number == 2)
            {
                //Computer selects Paper
                if (rockRadioButton.IsChecked == true)
                {
                    MessageBox.Show("Rock vs Paper. You lose!");
                }
                else if (paperRadioButton.IsChecked == true)
                {
                    MessageBox.Show("Paper vs Paper. Tie!");
                }
                else if (scissorsRadioButton.IsChecked == true)
                {
                    MessageBox.Show("Scissors vs Paper. You win!");
                }
            }
            else if (number == 3)
            {
               //Computer selects Scissors
               if (rockRadioButton.IsChecked == true)
               {
                   MessageBox.Show("Rock vs Scissors. You win!");
               }
               else if (paperRadioButton.IsChecked == true)
               {
                   MessageBox.Show("Paper vs Scissors. You lose!");
               }
               else if (scissorsRadioButton.IsChecked == true)
               {
                   MessageBox.Show("Scissors vs Scissors. Tie!");
               }
            }
            else
            {
            MessageBox.Show("The T-Rex broke.Sorry");
            }
          }
        private void rockRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Rock";
        }
        private void paperRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Paper";
        }
        private void scissorsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Scissors";
        }
