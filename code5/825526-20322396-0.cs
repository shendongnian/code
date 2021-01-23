    var indices = Enumerable.Range(0,myString.Count).ToList();
    //define some method to get next index
    public int? NextIndex(){
      if(indices.Count == 0) return null;
      int i = random.Next(indices.Count);
      indices.RemoveAt(i);
      return i;
    }
    if(my condition is met) {
     int? nextIndex = NextIndex();
     lbl.Text = nextIndex == null ? "" : myString[nextIndex.Value];
    }
