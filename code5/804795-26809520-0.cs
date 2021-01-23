    public string HashCode()
    {
        StringBuilder str = new StringBuilder();
        foreach (Car car in this.Positions)
        {
            //#yolo
            str.Append(string.Format("#{0}({1},{2})#", car.Original, car.Vector.X, car.Vector.Y));
        }
        return str.ToString();
    }
