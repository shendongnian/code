    public static Planet searchByName(String nameIn)
    {
        for (int i = 0; i < planetList.Count; i++)
        {
            if (planetList.ElementAt(i).name == nameIn)
            {
                return planetList.ElementAt(i);
            }
        }
        throw new System.ArgumentException(String.Format("Planet with name {0} does not exist", nameIn));
    }
