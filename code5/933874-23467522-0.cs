    // Keep this in the proper place 
    var indicators = new Code.Indicators();
    ...
    // Copy back and forth for the life time of the form
    using (var form = new Computer())
    {
        form.Indicators.AddRange(indicators);
        form.Close += (s, e) => 
            {
                indicators.Clear();
                indicators.AddRange(form.Indicators);
            }
    }
    ...
