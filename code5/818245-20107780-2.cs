    public LeafClass(MainClass oMainClass)
    {
        this.ID = oMainClass.ID;  // <-- oMainClass.ID is null because you never set it in oMainClass
        this.ID2 = "my 2nd ID";
    }
