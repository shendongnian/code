    void Update2()
    {
      var minValue = myItems.Min(i => i.Item1);       // Gets the minimum value in first column (so to speak);
      var maxValue = myItems.Max(i => i.Item1);       // Gets the maximum value.
      var rnd = new Random();
      var randNumber = rnd.Next(minValue, maxValue + 1);  // maximum value in Random.Next is exclusive.
      var myObject = myItems.SingleOrDefault(o => o.Item1 == randNumber);
      if (myObject != null)
        myItems.Remove(myObject);
    }
