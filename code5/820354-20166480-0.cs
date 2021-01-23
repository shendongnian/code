    for (int i = 0; i < DicitionaryCollection.Count; i++)
    {
        var methodPair = DicitionaryCollection[i];
        //... Do stuff
        var progressPercent = (i /(double)DicitionaryCollection.Count) * 100;
    }
