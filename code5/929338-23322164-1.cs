    private LinesDataSource dataSource = new LinesDataSource();
    private void Setup()
    {
        textBox.DataBindings.Add("Lines", dataSource, "LinesArray");
        Populate();
    }
    private void Populate()
    {
        dataSource.Lines.Add("whatever");
    }
