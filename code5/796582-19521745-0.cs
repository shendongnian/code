    public object[] properties;
    public int[] prop1 {
      get { return (int[]) properties[0]; }
      set { properties[0] = value; } }
    public string prop2 {
      get { return (string)properties[1];  }
      set { properties[1] = value ; } }
