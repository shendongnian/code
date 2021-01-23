    public static readonly DependencyProperty DevicesProperty =
    DependencyProperty.Register("Devices", typeof(List<Device>), typeof(CamaraSelection),
                            new PropertyMetadata(default(ItemCollection), OnDeviceListChanged));
    public List<Device> Devices
    {
        get { return (List<Device>)GetValue(DevicesProperty ); }
        set { SetValue(DevicesProperty, value); }
    }
