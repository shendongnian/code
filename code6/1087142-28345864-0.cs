    public void OnUpdate()
    {
       var orderedEnumerable = ScoresList.OrderByDescending (s => s.Score);
  
       foreach (var s in orderedEnumerable.Take (numberToDisplay)) 
       {
          s.Displayed = true;
       }
       foreach (var s in orderedEnumerable.Skip(numberToDisplay)) 
       {
          s.Displayed = false;
       }
    }
