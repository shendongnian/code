    btn[x, y].Click += btnClick;
    btn[x, y].Tag = "..."; //Based on background
 
    public void btnClick(object sender, EventArgs e)
    {
       Button myButton = sender as Button;
       if (myButton.Tag == "Mountain")
       { ... }
       else if (myButton.Tag == "Forest")
       { ... }
    }
