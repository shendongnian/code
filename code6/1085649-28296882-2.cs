    private static bool TryParsePoint3d(string x, string y, string z, out Point3d output)
    {
        double xValue, yValue, zValue;
    
        if (double.TryParse(x, out xValue) &&
            double.TryParse(y, out yValue) &&
            double.TryParse(z, out zValue))
        {
            output = new Point3d(xValue, yValue, zValue);
            return true;
        }
    
        // out params must be assigned, use null if it's a class
        output = new Point3d();
        return false;
    }
