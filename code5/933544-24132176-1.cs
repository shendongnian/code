    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
    
        if (e.KeyChar == (char)Keys.Up)
        {
            //sp.Open();
            sp.Write("u");
            //sp.Close();
        }
        else if (e.KeyChar == (char)Keys.Down)
        {
            //sp.Open();
            sp.Write("d");
            //sp.Close();
        }
        else if (e.KeyChar == (char)Keys.Right)
        {
            //sp.Open();
            sp.Write("r");
            //sp.Close();
        }
    }
