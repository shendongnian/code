    public int Count {
      get { return count;}
      set {
        int i = value - count;
        count = value;
        if(i == 1) push();
        else if(i == -1) pop();
      }
    }
    //then do it like this
    Count += check ? 1 : -1;
