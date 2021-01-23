    List<HitObject> detected = new List<HitObject>();
    detected.Add(new HitObject
    {
        V1 = "bob",
        V2 = 1f,
        V3 = 2.5f
    });
    HitObject something = new HitObject
    {
        V1 = "bob",
        V2 = 3f,
        V3 = 3.5f
    };
    if (!detected.Contains(something))
    {
        // this line will not be executed
        detected.Add(something);
    }
