    KeyValuePair<T1, T2>[] items;
    List<KeyValuePair<T1, T2>> matches = new ...(); //Consider pre-sizing this.
    
    //This could be a parallel loop as well.
    //Make sure to not synchronize too much on matches.
    //If there tend to be few matches a lock will be fine.
    foreach (var item in items) {
     if (IsMatch(item)) {
      matches.Add(item);
     }
    }
    
    matches.Sort(...); //Sort in-place
    
    return matches.Take(10); //Maybe matches.RemoveRange(10, matches.Count - 10) is better
