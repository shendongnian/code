    private void DisplayCats()
    {
        foreach (Pets temp in thisApp.pets)
        {
            if (temp.Category.Contains("Cat"))
            {
                //note that I added the ID property --v
                Animal animal = new Animal() { ID = temp.ID, Details = temp.Name + "\n" + temp.Category + " / " + temp.Subcategory + "\n€" + temp.Price.ToString(), ImageURI = temp.Image };
                lstCats.Items.Add(animal);
            }
        }
    }
