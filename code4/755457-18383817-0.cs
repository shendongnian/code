    //Gets the number contained in a Node's header
    public static int getNumber(string parentNodeHeader)
    {
          int curNumber;
          //if parse to Int32 fails, curNumber will still be 0
          Int32.TryParse(parentNodeHeader, out curNumber);
          return curNumber;
    }
