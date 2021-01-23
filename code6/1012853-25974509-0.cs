        void generateGraphImg()
        {
            PieChart pc = new PieChart();
            pc.LayoutUpdated += pc_LayoutUpdated;
            ObservableCollection<TestClass> Errors = new ObservableCollection<TestClass>();
            Errors.Add(new TestClass() { Category = "Globalization", Number = 75 });
            Errors.Add(new TestClass() { Category = "Features", Number = 2 });
            Errors.Add(new TestClass() { Category = "ContentTypes", Number = 12 });
            Errors.Add(new TestClass() { Category = "Correctness", Number = 83 });
            Errors.Add(new TestClass() { Category = "Best Practices", Number = 29 });
            ChartSeries Charts = new ChartSeries();
            Charts.SeriesTitle = "Errors";
            Charts.DisplayMember = "Category";
            Charts.ValueMember = "Number";
            Charts.ItemsSource = Errors;
            pc.Series.Add(Charts);
            pc.ChartTitle = "Minimal Pie Chart";
            pc.ChartSubTitle = "Chart with fixed width and height";
            makeImgFromControl(pc, @"C:\Modern UI IMG\img.bmp");
        }
        void pc_LayoutUpdated(object sender, EventArgs e)
        {
            RenderTargetBitmap render = new RenderTargetBitmap(500,500, 150, 150, PixelFormats.Pbgra32);
            render.Render(viewbox);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(render));
            using (Stream s = File.Create(@"C:\Modern UI IMG\img.bmp"))
            {
                encoder.Save(s);
            }
        }
        Viewbox viewbox;
        void makeImgFromControl(UIElement control, string saveTo)
        {
            viewbox = new Viewbox();
            viewbox.Child = control; //control to render
            viewbox.Measure(new System.Windows.Size(200, 200));
            viewbox.Arrange(new Rect(0, 0, 200, 200));
            viewbox.UpdateLayout();
        }
