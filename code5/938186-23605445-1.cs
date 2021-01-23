    Enum eNUM
    {
        one, two, three ...
    }
    ...
    eNUM num;
    string findThisValue = "OnE"; // Odd casing...
    if (Enum.TryParse(findThisValue.ToLower(), out num))
    {
        // Do something with num
    }
