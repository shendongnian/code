    //This will not work.
    foreach (string rs in list)
    {
        if (some_test)
        {
            list.Remove(rs); //Because of this line.
        }
    }
