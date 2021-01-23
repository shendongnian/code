    ObservableCollection<TestClass> blocks = new ObservableCollection<TestClass>(); 
    ChartSeries chartSerie = new ChartSeries();
                chartSerie.SeriesTitle = "Some Title"
                chartSerie.DisplayMember = "Category";
                chartSerie.ValueMember = "Number";
                Bars.Add(chartSerie);
                chartSerie.ItemsSource = blocks;
                blocks = new ObservableCollection<TestClass>();
