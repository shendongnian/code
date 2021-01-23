    private static readonly Size MaxResolution = GetMaxResolution();
    private static double AspectRatio = (double)MaxResolution.Width / MaxResolution.Height;
    private readonly PointF Dpi;
    public YourForm() // constructor
    {
        Dpi = GetDpi();
        AspectRatio *= Dpi.X / Dpi.Y;
    }
    private PointF GetDpi()
    {
        PointF dpi = PointF.Empty;
        using (Graphics g = CreateGraphics())
        {
            dpi.X = g.DpiX;
            dpi.Y = g.DpiY;
        }
        return dpi;
    }
    private static Size GetMaxResolution()
    {
        var scope = new ManagementScope();
        var q = new ObjectQuery("SELECT * FROM CIM_VideoControllerResolution");
        using (var searcher = new ManagementObjectSearcher(scope, q))
        {
            var results = searcher.Get();
            int maxHResolution = 0;
            int maxVResolution = 0;
            foreach (var item in results)
            {
                if (item.GetPropertyValue("HorizontalResolution") == null)
                    continue;
                int h = int.Parse(item["HorizontalResolution"].ToString());
                int v = int.Parse(item["VerticalResolution"].ToString());
                if (h > maxHResolution || v > maxVResolution)
                {
                    maxHResolution = h;
                    maxVResolution = v;
                }
            }
            return new Size(maxHResolution, maxVResolution);
        }
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        int minWidth = Math.Min(Width, (int)(Height * AspectRatio));
        if (WindowState == FormWindowState.Normal)
            Size = new Size(minWidth, (int)(minWidth / AspectRatio));
    }
