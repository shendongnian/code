    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Elapsed += new ElapsedEventHandler(RealTimeGraph)
    Public void RealTimeGraph(object sender, EventArgs e)
    {
      if (this.InvokeRequired)
      {
        PeriodicUpdateHandler update = new PeriodicUpdateHandler(this.RealTimeGraph);
        this.BeginInvoke(periodisches_update,sender, e);
      }
      else
      {
        Update();                          // check if new data for ZedGraph is available
        ZedGraph.GraphPane.AxisChange();   // optional, if ZedGraphAxis has to be recomputed
        ZedGraph.control.Invalidate();     // optional
        ZedGraph.control.Refresh();        // now the update is visible
      }
    }
