    for(int i = 0; i < myButtons.Length; i++)
    {
         myButtons[i].Click += new EvenrHandler(Display(i));
    }
    private void Display(int i)
    {
        MessageBox.Show("Button No " + i);
    }
