    public static Planet searchByName(String nameIn)
    {
        for (int i = 0; i < planetList.Count; i++)
        {
            Planet planet = planetList.ElementAt(i);
            if (nameIn == planet.name)
                return planet;
        }
        throw new System.ArgumentException(String.Format("Planet with name {0} does not exist", nameIn));
    }
