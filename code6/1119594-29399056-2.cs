      people.Add(p1);
      people.Add(p3);
      otherPeople.Add(p2);
      var ThemPeople = people.Except(otherPeople);
      // gives you p1 and p3
      var ThemOtherPeople = people.Except(otherPeople, new PersonSsidEqualityComparar());
      // only gives you p3
      otherPeople.Add(p4);
      var DoingReferenceComparesNow = people.Except(otherPeople);
      // gives you only p3 cause p1 == p4 (they're the same address)    
