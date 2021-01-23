    public int USCurren()
        {
            string input = textBox1.Text;
            int value = -1;
            try
            {
                if (int.TryParse(input, out value) && value > 0)
                {
                    //Write your code here to convert the currency;
                    return value;
                }
                else
                {
                    MessageBox.Show("Please Input A Positive Integer");
                    textBox1.Clear();
                    value = -1;
                }
            }
            catch (Exception ex)
            {
                //Show exception here
            }
            return value;
        }
