    private IList<IPaintable> GetPaintables(ObjectType type)
    {
       switch (type)
        {
            case ObjectType.Car:
                 return this.cars;
            case ObjectType.House:
                 return this.houses;
            case ObjectType.Paper:
                 return this.papers;
            default:
                 throw new ArgumentOutOfRangeException();
        }
    }
