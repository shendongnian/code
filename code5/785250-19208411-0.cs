    public void Lépés(ref Button but1, ref Button but2)
    {
            if (but2.Text == "")
            {
                but2.Text = but1.Text;
                but1.Text = "";
            }                
    }
