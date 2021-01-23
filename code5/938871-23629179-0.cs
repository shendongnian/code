    int TestNumber = int.Parse(primeNumberTextBox.Text);
    bool isPrime = false;
    for (int i = 2; i < TestNumber-1; i++)
    {
        if (TestNumber % i == 0)
        {
            isPrime = true;
            yesNoPrimeTextBox.Text = "prime";
            break;
        }       
    }
}
