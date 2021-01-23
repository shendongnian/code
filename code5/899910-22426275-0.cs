    if(Enumerable.Range(80,100).Contains(Total))
    {
        MessageBox.Show("You got an A!");
    }
    else if(Enumerable.Range(60, 79).Contains(Total))
    {
        MessageBox.Show("You got a B!");
    }
    else if(Enumerable.Range(50, 59).Contains(Total))
    {
        MessageBox.Show("You got a C!");
    }
    else if(Enumerable.Range(40, 49).Contains(Total))
    {
        MessageBox.Show("You got a D!");
    }
    else if(Enumerable.Range(0, 39).Contains(Total))
    {
        MessageBox.Show("You got an E...");
    }
