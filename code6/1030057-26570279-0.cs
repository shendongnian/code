     ReportDocument rd = new ReportDocument();
        rd.Load(str);
        ParameterField p=new ParameterField();
        p.Name="parm1";
        ParameterDiscreteValue pv = new ParameterDiscreteValue();
        pv.Value = "value1";
        p.CurrentValues.Add(pv);
        string str = Path.Combine(Application.StartupPath, "Print\\rpt1.rpt");
        //rd.SetParameterValue("parm1", "test");
        
        rd.ParameterFields.Add(p);
        var dialog = new PrintDialog();
        rd.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName;
        rd.PrintToPrinter(1, false, 0, 0);
    it works correctly.
