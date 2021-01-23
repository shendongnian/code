    List<hitOBject> Detected = new List<hitOBject>();
    var MyEqualityComparer = new hitObjectV1EqualityComparer();
    Detected.Add(new hitOBject {v1 = "bob", v2 = 1f, v3 = 2.5f});
    
    hitOBject secondObject = new hitOBject {v1 = "bob", v2 = 1f, v3 = 2.5f};
    if (Detected.Contains(secondObject, MyEqualityComparer))
    {
        //Already Exists
    }
    else
    {
        Detected.Add(secondObject);    
    }
