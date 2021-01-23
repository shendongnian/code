    public void MyMethod(double fish = Double.NaN)
    {
        if (Double.IsNaN(fish))
            fish = MyCPlusPlusCLILib.CPPCLIClass.Invalid;
        ...
    }
