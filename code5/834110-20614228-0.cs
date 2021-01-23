    private void InitializeChart()
    {
      tChart1.Graphics3D = new Graphics3DDirect2D(tChart1.Chart);
      tChart1.Aspect.View3D = false;
      FastLine series = new FastLine(tChart1.Chart);
      series.FillSampleValues(1000);
     
    }
    TChart tChart2;
    private void button1_Click(object sender, EventArgs e)
    {
      if(tChart2 == null) tChart2 = new TChart();
      MemoryStream ms = new MemoryStream();
      tChart1.Export.Template.Save(ms);
      ms.Position = 0;
      tChart2.Import.Template.Load(ms);
      tChart2.Export.Image.PNG.Width = tChart1.Width;
      tChart2.Export.Image.PNG.Height = tChart1.Height;
      tChart2.Export.Image.PNG.Save(@"C:\tmp\direct2d.png");
    }
