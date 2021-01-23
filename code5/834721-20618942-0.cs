    public Form1() {
      InitializeComponent();
      x_index = -1;
      if (graph1.Series == null) {
        graph1.Series = new SeriesCollection();
      }
      graph1.AxisViewChanging += new EventHandler<ViewEventArgs>(graph1_AxisViewChanging);
      graph1.AxisViewChanged += new EventHandler<ViewEventArgs>(graph1_AxisViewChanged);
    }
