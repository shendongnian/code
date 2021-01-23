    try
      {
        Installer.SetInternalUI(InstallUIOptions.Silent); // Set MSI GUI level
        Installer.ConfigureProduct(productcode, 0, InstallState.Absent, "REBOOT=\"ReallySuppress\"");
      }
      catch (Exception e)
      {
         Console.WriteLine("Exception: " + e.Message);
         Console.ReadLine (); // Keep console window open
      }
