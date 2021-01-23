    private readonly Devices _parent;
    public Device_Options(Devices parent)
    {
      InitializeComponent();   
      _parent = parent;
      deviceLabel.Text = _parent.selectedDevice;
    }
