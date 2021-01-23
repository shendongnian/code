    List<Keys> vowelz = new List<Keys>
    {
        Keys.A, Keys.B, Keys.B, Keys.B
    }
    public void vowelbutton_Click(object sender, EventArgs e)
    {
        Random randomizer = new Random();
        var indexz1 = randomizer.Next(0, vowelz.Count);
        var keyz1 = vowelz[indexz1];
        listBox1.Items.Add(vowelz[indexz1]);
        vowelz.RemoveAt(indexz1);
    }  
