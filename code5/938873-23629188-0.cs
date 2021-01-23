    protected void isPrimeButton_Click(object sender, EventArgs e)
    {
    
        int TestNumber = int.Parse(primeNumberTextBox.Text);
        bool isPrime = true;
    
        for (int i = 2; i < TestNumber; i++)
        {
            if (TestNumber % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            yesNoPrimeTextBox.Text = "prime";
        else
            yesNoPrimeTextBox.Text = "not prime";
    
    }
