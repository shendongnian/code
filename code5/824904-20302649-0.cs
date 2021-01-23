    // add one item
    while(buttonQueue.Count > 0) // Count is 1
    {
        buttonQueue.Dequeue(); // remove one item
        listBox.Items.Add("Number: " + buttonQueue.Count); // Count is 0
    }
