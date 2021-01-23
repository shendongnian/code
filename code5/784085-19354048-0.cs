    Photoshop.Application appRef = default(Photoshop.Application);
    appRef.Preferences.RulerUnits = PsUnits.psPixels;
    foreach (ColorSampler sampler in appRef.ActiveDocument.ColorSamplers)
    {
      // Check to see what underlying type a sampler is so you can try
      // and make instances of this to pass into the Add method.
      Console.WriteLine(sampler.GetType().FullName);
    }
      
    // Try add an object array of double values, based on the error message implied units could work.
    // 'D' with convert the number literal to a 'double'.
    appRef.ActiveDocument.ColorSamplers.Add(new object[] { 0.5D, 0.5D } );
