    private void ShowUomoFilter(object sender, FilterEventArgs e)
    {
        if (checkBox1.Checked)
        {
            Testo item = (Testo)e.Item;
            if (item.Sesso == "Uomo")
               e.Accepted = true;
            else
               e.Accepted = false;
        }
        else
           e.Accepted = true;
    }
