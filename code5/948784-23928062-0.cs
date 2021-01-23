    PrintingSystem printingSystem1;
    void somemethod()
    {
     DevExpress.XtraPrinting.PrintableComponentLink pl = new     DevExpress.XtraPrinting.PrintableComponentLink();
            printingSystem1.Links.Add(pl);
           pl.Component = _gridControl;
     pl.CreateReportHeaderArea += new CreateAreaEventHandler(pl_CreateReportHeaderArea);
    }
     void pl_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
                TextBrick brick1 = e.Graph.DrawString("Your text goes here", Color.Black,
                   new RectangleF(0, 0, 620,20), DevExpress.XtraPrinting.BorderSide.None);
                brick1.HorzAlignment = HorzAlignment.Center;
                brick1.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
      }
