    //Declare this globally
    Dictionary<string, Button> Dic = new Dictionary<string, Button>(81);
    //put this in the constructor
    for(int i=0; i<81; i++)
    {
        Button b = new Button();
        b.Text = i; //or Random or whatever
        b.Name = "btn" + i.ToString();
        this.Controls.Add(b);
        Dic.Add(b.Name, b);
    }
