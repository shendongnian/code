            MasterPane master = zg1.MasterPane;
            master.PaneList.Clear();
            //Title of graph
            master.Title.IsVisible = true;
            master.Title.Text = SPolohaE+"E----"+SPolohaN+"N";
            master.Margin.All = 10;
        
            /*Background collor*/
            master.Fill = new Fill(Color.Blue, Color.LightBlue, 45.0f);
            GraphPane pane1 = new GraphPane();
            /*New list for graph*/
            PointPairList list1 = new PointPairList();
            string date, time, y;
            double Y_axis, X_axis;
            /*load data row to row*/
            for (int rows = 0; rows < pocet_Radku-1; rows++)
            {
                    /*load data from datagridview*/
                    date = dataGridView1.Rows[rows].Cells[2].Value.ToString();
                    time = dataGridView1.Rows[rows].Cells[1].Value.ToString();
                    y = dataGridView1.Rows[rows].Cells[5].Value.ToString();
                    Y_axis = double.Parse(y);
                    string[] datum = date.Split(' ');
                    DateTime dt = Convert.ToDateTime(datum[0]+" "+time);
                    /*Create X axis*/
                    X_axis = (double) new XDate(dt);
                    /*add to list data*/
                    list1.Add(X_axis, Y_axis);
            }
            /*Type of X axes*/
            pane1.XAxis.Type = AxisType.Date;
            pane1.Title.Text = "Teplota 1"; //Title of char
            LineItem Graf1 = pane1.AddCurve("", list1, Color.Black, SymbolType.Diamond);
            //Add graph
            master.Add(pane1);
            //Set graph
            using (Graphics g = this.CreateGraphics())
            {
                master.SetLayout(g, true, new int[] { 3, 3, 2 });   /
            }
            /*init axes*/
            zg1.AxisChange();
            zg1.Invalidate();
	}
