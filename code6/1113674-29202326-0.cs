    public Form1()
            {
                InitializeComponent();
                textBox1.Text = "20000";
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                FormatText();
            }
    
            private void FormatText()
            {
                if (String.IsNullOrWhiteSpace(textBox1.Text)) // Validate input
                    return; 
                decimal amount;
                Decimal.TryParse(textBox1.Text, out amount);
                if (amount == 0) // Validate if it's a number
                    return;
                textBox1.Text = "$" + String.Format("{0:n0}",amount); // Format with no decimals
                textBox1.Select(textBox1.Text.Length, 0); // Set the cursor position to last character
            }
