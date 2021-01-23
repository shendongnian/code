    foreach (A a in listA)
    {
        if (a.GetType().ToString() == "Test.B")
        {
            listA.Remove(a);
            listB.Add((B) a);
        }
    }
