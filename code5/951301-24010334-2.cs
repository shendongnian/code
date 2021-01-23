    var binding = new Binding("Left", control1, "Size", true,DataSourceUpdateMode.Never);
    binding.Format += (sender, args) =>
    {
        if (args.DesiredType == typeof (int))
        {
            Size size = (Size) args.Value;
            args.Value = size.Width;
        }
    };
    control2.DataBindings.Add(binding);
