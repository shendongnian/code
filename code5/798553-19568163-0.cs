    private Dictionary<string, string> list = new Dictionary<string, string>();
    
    public void MyMethod(string a) {
       lock (list) {
          if (list.Contains(a))
            return;
          list.Add(a,"someothervalue");
        }
    }
