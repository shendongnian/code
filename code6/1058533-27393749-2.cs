     dates.Sort();
     //this will hold the resulted groups
     var groups = new List<List<DateTime>>();
     // the group for the first element
     var group1 = new List<DateTime>(){dates[0]};
     groups.Add(group1);
    
     DateTime lastDate = dates[0];
     for (int i = 1; i < dates.Count; i++)
     {
         DateTime currDate = dates[i];
         TimeSpan timeDiff = currDate - lastDate;
         //should we create a new group?
         bool isNewGroup = timeDiff.Days > 1;
         if (isNewGroup)
         {
             groups.Add(new List<DateTime>());
         }
         groups.Last().Add(currDate);
         lastDate = currDate;
     }
