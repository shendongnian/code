    public Class Customer {
       public int CustomerId { get; set; }
       public string First { get; set; }
       public string Last { get; set; }
       // here is where you decide what to display in the combo box:
       public override string ToString() { return First + Last; }
    }
