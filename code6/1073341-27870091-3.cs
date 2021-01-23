    public Form1()
    {
      this.InitializeComponent();
      this.Examples = new BindingList<Example>() 
      {
        new Example() { First = "Foo", Last = "Bar", Test = "Small" },
        new Example() { First = "My", Last = "Example", Test = "You." }
      };
      this.dataGridView1.DataSource = this.Examples;
      this.Visible = true; // Do this or during the initial resize, the columns will still be 100 width.
      this.dataGridView1_Resize(this.dataGridView1, EventArgs.Empty); // Invoke our changes.
      //this.Examples[0].Test = "ReallyBigExampleOfTextForMySmallLittleColumnToDisplayButResizeToTheRescue";
    }
