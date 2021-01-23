    if (LCheck.Checked)
    {
        LineItem line1 = myPane.AddCurve("LINE1",
            LL, Color.Red, SymbolType.None);
    }
    else
    {
        LL.Clear();
    }
    zgc.AxisChange();
    zgc.Invalidate();
    zgc.Refresh(); 
