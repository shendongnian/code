    int guess;
    bool numberEntered = int.TryParse(textBox1.Text, out guess);
    
    if (!numberEntered)
        MessageBox.Show("Invalid characters detected!");
    else if (guess > 100)
        MessageBox.Show("Number too big!");
    else if (guess < 1)
        MessageBox.Show("Number too small!");
