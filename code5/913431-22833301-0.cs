    public void UpdateForm()
    {
        if (administration == null)
        {
            administration = new TypeOfAdministration();
        }
        if (administration.Animals != null)
        {
            List<string> reservedAnimals = new List<string>();
            List<string> notReservedAnimals = new List<string>();
            lbReserved.Items.Clear();
            foreach (Animal a in administration.Animals)
            {
                if (a.IsReserved == true)
                {
                    reservedAnimals.Add(a.ToString());
                }
            }
        }    
    }
