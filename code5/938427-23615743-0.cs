    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        int hash = Tuple<Keys, Keys>(e.KeyCode, e.Modifiers).GetHashCode();
        switch (hash)
        {
            case new Tuple<Keys, Keys>(Keys.B, Keys.Control).GetHashCode():
                //something happens here
            break;
        }
    }
