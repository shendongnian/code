    /// <summary>
    /// Initialize the Options and add content to each.
    /// New up the Checked lists.
    /// </summary>
    public Form1()
    {
      InitializeComponent();
      this.SourceIndex = -1;
      this.checkedListBox1.CheckOnClick = true;
      this.Checked = new List<int>[]
      {
        new List<int>(),
        new List<int>(),
        new List<int>(),
      };
      this.Options = new Dictionary<int,string>[3];
      // Fruit Options
      this.Options[0] = new Dictionary<int, string>();
      this.Options[0].Add(0, "Apple");
      this.Options[0].Add(1, "Banana");
      this.Options[0].Add(2, "Orange");
      this.Options[0].Add(3, "Grapes");
      // Meat Options
      this.Options[1] = new Dictionary<int, string>();
      this.Options[1].Add(0, "Beef");
      this.Options[1].Add(1, "Chicken");
      this.Options[1].Add(2, "Pork");
      this.Options[1].Add(3, "Lamb");
      // Drink Options
      this.Options[2] = new Dictionary<int, string>();
      this.Options[2].Add(0, "Milk");
      this.Options[2].Add(1, "Water");
      this.Options[2].Add(2, "Juice");
      this.Options[2].Add(3, "Soda");
    }
