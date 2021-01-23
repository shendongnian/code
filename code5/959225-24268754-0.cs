    using PsionTeklogix.Backlight;
    ...
    if (BacklightControl.IsSupported())
    {
         BacklightControl.DisplayBacklightIntensity = lightingScreenTrackBar.Value;
    }
