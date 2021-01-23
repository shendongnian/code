    try
    {
        var cr13_installed = System.Reflection.Assembly.Load(
            "CrystalDecisions.CrystalReports.Engine, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
        );
    }
    catch (System.IO.FileNotFoundException)
    {
        // not installed
    }
