    /*Initial pane settings*/
    pane.XAxis.Type = AxisType.Date;
    pane.XAxis.Scale.Format = "dd/MM/yy\nH:mm:ss";
    pane.XAxis.Scale.Min = (XDate)(DateTime.Now);
    //Shows 25 seconds interval.
    pane.XAxis.Scale.Max = (XDate)(DateTime.Now.AddSeconds(25));
    pane.XAxis.Scale.MinorUnit = DateUnit.Second;
    pane.XAxis.Scale.MajorUnit = DateUnit.Minute;
    pane.XAxis.MajorTic.IsBetweenLabels = true;
    pane.XAxis.MinorTic.Size = 5;
    /*Real time plotting*/
    XDate time = new XDate(DateTime.Now.ToOADate());
    LineItem curve= curve= myPane.CurveList[0] as LineItem;
    IPointListEdit list = list = curve.Points as IPointListEdit;
    list.Add(time,data);
    //Scale pane if current time is greater than the initial xScale.Max
    Scale xScale = zgcMasterPane.MasterPane.PaneList[0].XAxis.Scale;
    if (time.XLDate > xScale.Max)
    {
      xScale.Max = (XDate)(DateTime.Now.AddSeconds(5));
      xScale.Min = (XDate)(DateTime.Now.AddSeconds(-20));
    }
