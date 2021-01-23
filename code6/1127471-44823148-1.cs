    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IntPtr hWnd = Window.Handle;
        System.Windows.Forms.Control ctrl = System.Windows.Forms.Control.FromHandle(hWnd);
        System.Windows.Forms.Form form = ctrl.FindForm();
        form.TransparencyKey = System.Drawing.Color.Black;
    }
