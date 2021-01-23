    if (int.TryParse(textBoxDivisor.Text, out divisorInt))
            {
                if (divisorInt != 0)
                {
                //correct
                }
                else
                {
                     // blah blah blah
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid divisor!");
                return;
            }
