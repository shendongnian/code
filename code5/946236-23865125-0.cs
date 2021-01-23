    private void button_Click(object sender, EventArgs e)
    {
       // Add the clicked button to the list
       pressedButtons.Add((Button)sender);
    
       // If all 3 are on the list, enable button4
       if (pressedButtons.Count == 3) { button4.Enabled = true; }
    }
