    public PlotModel GraphModel { get; private set; }
        public void AddPoints(double xPoint, double yPoint)
        {
            (this.GraphModel.Series[0] as LineSeries).Points.Add(new DataPoint(xPoint, yPoint));
            GraphModel.InvalidatePlot(true);
            //if autopan is on and actually neccessary
            if ((AutoPan) && (xPoint > GraphModel.Axes[0].Maximum))
            {
                //the pan is the actual max position of the observed Axis minus the maximum data position times the scaling factor
                var xPan = (GraphModel.Axes[0].ActualMaximum - GraphModel.Axes[0].DataMaximum) * GraphModel.Axes[0].Scale;
                GraphModel.Axes[0].Pan(xPan);
            }          
        }
