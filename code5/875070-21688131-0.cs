    public IEnumerable<OphControl> OphControls {
        get {
            return Controls.Cast<Control>().Where(control => control is OphControl).Cast<OphControl>();
        }
    }
