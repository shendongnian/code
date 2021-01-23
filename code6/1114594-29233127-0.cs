    public CustomToolStripControlHost(Control c)
            : base(c)
        {
            NumericUpDown numUpDown = (NumericUpDown)c;
            numUpDown.DecimalPlaces = 10;
        }
