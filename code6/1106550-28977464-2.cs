    public static Planet searchByName(String nameIn)
    {
        Planet planet = planetList.FirstOrDefault(p => p.name == nameIn);
        if (planet != null)
        {
            return planet;
        }
        else
        {
            throw new System.ArgumentException(String.Format("Planet with name {0} does not exist", nameIn))
        }
    }
