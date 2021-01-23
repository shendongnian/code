    public static Planet searchByName(String nameIn)
    {
        for (var planet in planetList)
        {
            if (planet.name == nameIn)
            {
                return planet;
            }
        }
        throw new System.ArgumentException(String.Format("Planet with name {0} does not exist", nameIn));
    }
