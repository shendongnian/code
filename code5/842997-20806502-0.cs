    private double? _camber;
    public double? Camber
    {
        get
        {
            return ModelSettings.CamberEnabled
                ? _camber
                : null;
        }
        set;
    }
