    {         
        PointPairList list1 = new PointPairList();
        list1.Add(5, 1);
        list1.Add(10, 2);
        BarItem bar1 = zedGraphControl1.GraphPane.AddBar("A", list1, Color.Blue);
        zedGraphControl1.GraphPane.BarSettings.Base = BarBase.Y;
        zedGraphControl1.GraphPane.XAxis.Scale.Max = 768;
        zedGraphControl1.GraphPane.YAxis.Type = AxisType.Text;
        
        zedGraphControl1.AxisChange();
        zedGraphControl1.Refresh();
    }
