    TypeWithRand randtype;
    ...
    void Start()
    {
        randtype = objWithRand.GetComponent<TypeWithRand>();
    }
    ...
    if (randtype.randID == zoneID)
    {
        ...
    }
