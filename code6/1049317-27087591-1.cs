    private int _number { get; set; }
    public int Number{
      get { return _number ; }
      set { _number = value; }
    }
    
    public BallUc(int number) {
      Number = number;
      InitializeComponent();
      MessageBox.Show(this.Number.ToString());
    }
