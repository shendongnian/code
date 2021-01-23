    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 1;
        }
        if (obj is Animal)
        {
            Animal other = (Animal)obj;
            return this.Name.CompareTo(other.Name);
        }
        return 1;  // or whatever behavior you want if obj is not an Animal
    }
