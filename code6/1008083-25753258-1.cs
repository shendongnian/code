    IndexViewModel viewModel = new IndexViewModel()
    {
          reportContentsCharts = reportContentsCharts
    }
    for (int i = 0; i < 6; i++)
    {
        viewModel.AddChart("chart" + i, makeChart("chart" + i, DictionaryOfData));
    }
    
