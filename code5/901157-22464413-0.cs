    private void DisplayCats()
    {
        foreach (Pets temp in thisApp.pets)
        {
            if (temp.Category.Contains("Cat"))
            {
                lstCats.Items.Add(temp);
            }
        }
    }
