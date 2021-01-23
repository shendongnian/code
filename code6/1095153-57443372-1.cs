    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        Processing();
        textview2.Buffer.Text = out0;
    }
