    public string LengthyProc(int sleepTime) {
      this.Timeout = 10000; //10 seconds
      object[] results = this.Invoke("LengthyProc", new object[] {sleepTime});
      return ((string)(results[0]));  
    }
