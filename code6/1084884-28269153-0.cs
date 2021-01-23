    int num;
    if (Int32.TryParse(rosesTextBox.Text, out num)
    {
        // do something with num. it is an int.
    }
    else
    {
        MessageBox.Show("Please input a whole number for the number of roses");
    }
