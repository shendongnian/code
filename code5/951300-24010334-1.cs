    var binding = new Binding("Left", button2, "Size", true,DataSourceUpdateMode.Never);
    binding.Format += (sender, args) =>
    {
        if (args.DesiredType == typeof (int))
        {
            Size size = (Size) args.Value;
            args.Value = size.Width;
        }
    };
    button1.DataBindings.Add(binding);
