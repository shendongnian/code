        spelersSpel.Clear();
        foreach (TextBox item in spelers)
        {
            if (!string.IsNullOrWitheSpace(item.Text))
                spelersSpel.Add(item.Text);
        }
