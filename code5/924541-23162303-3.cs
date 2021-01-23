    private void readW_TextChanged(object sender, EventArgs e)
    {
        string _W = readW.Text;
        if(Decimal.TryParse(_W, out _Wd))
        {
            Console.WriteLine("Valid decimal entered!");
        } 
    }
