    private void InitializeChart()
    {
      Donut series = new Donut(tChart1.Chart);
      series.FillSampleValues();
      series.Marks.Visible = true;
      series.Marks.Transparent = true;
      series.Marks.Arrow.Visible = false;
      series.Marks.ArrowLength = -10;
    }
