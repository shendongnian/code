    public int USCurren(int value)
    {   
        string input = textBox1.Text;
        bool bIsTrue = true;
        while (bIsTrue)
        {
            if (int.TryParse(input, out value) && value > 0)
            {
                //Write your code here to convert the currency;
                return value;
            }
            else
            {
                    bIsTrue = false;
                    MessageBox.Show("Please Input A Positive Integer");
                    textBox1.Clear();
            }
        }
    }
