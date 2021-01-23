    protected void txttotal_TextChanged(object sender, EventArgs e)
    {
        int a = 0;
        int b = 0;
        int c = 0;
        if (!Int32.TryParse(txtmaths.Text, ref a))
            // handle error...
        if (!Int32.TryParse(txtsci.Text, ref b))
            // handle error...
        if (!Int32.TryParse(txtenglish.Text, ref c))
            // handle error...
        int tot = a + b + c;
        txttotal.Text = Convert.ToString(tot);
    }
