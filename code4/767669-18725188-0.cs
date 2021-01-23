    Form1_Load(object sender, EventArgs e) {
        Timer t = new System.Windows.Forms.Timer();
        t.Interval = 5000;
        t.Tick += SomeEventHandlerThatLoadsAndDisplaysTheNextImage;
        t.Start();
    }
