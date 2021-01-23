    List<hitOBject> Detected = new List<hitOBject>();
    Detected.Add(new hitOBject {v1 = "bob", v2 = 1f, v3 = 2.5f});
    hitOBject secondObject = new hitOBject {v1 = "bob", v2 = 1f, v3 = 2.5f};
    if (Detected.Contains(secondObject))
    {
        Console.WriteLine("Alread Exists");
    }
