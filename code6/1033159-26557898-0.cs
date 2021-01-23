    private const string InputFirst = "Input first integer";
    private const string InputSecond = "Input second integer";
    private const string InputThird = "Input third integer";
    private int integersEntered;
    private void Form1_Load(object sender, EventArgs e)
    {
        button1.Text = InputFirst;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (ValidateInput(textBox1.Text))
        {
            textBox1.Clear();
            switch (integersEntered)
            {
                case 1:
                    button1.Text = InputSecond;
                    break;
                case 2:
                    button1.Text = InputThird;
                    break;
                case 3:
                    button1.Text = InputFirst;
                    button1.Enabled = false;
                    break;
            }
        }
        else
        {                
            MessageBox.Show("You must enter a valid integer.", "Text Validation");
            textBox1.Focus();
            textBox1.SelectAll();
        }
    }
    private bool ValidateInput(string input)
    {
        int value;
        var success = int.TryParse(input, out value);
        if(success) { integersEntered++; }
        return success;
    }
