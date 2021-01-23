    public static Thing CreateFromMass(int mass)
    {
        return new Thing(mass, 0);
    }
    public static Thing CreateFromVol(int vol)
    {
        return new Thing(0, vol);
    }
