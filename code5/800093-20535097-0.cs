    //declare the x coordinate (time) variable
    double xValue = 0;
    
    //setting the Axis
    pane.XAxis.Scale.MinorStep = 1;
    pane.XAxis.Scale.MajorStep = 5;
    pane.XAxis.Scale.Max = 0;
    pane.XAxis.Scale.Min = -10;
    
        //drawing the data
        private void draw(double dataValue)
        {
         LineItem curve1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
         IPointListEdit list1 = curve1.Points as IPointListEdit;
        
         list1.Add(xValue*(20/1000), dataValue); //
        
         //Scroll
         Scale XScale = zedGraphControl1.GraphPane.XAxis.Scale as Scale;
         XScale.Max = xValue*(20/1000);
         XScale.Min = XScale.Max - 10;
        
         xValue++;
         zedGraphControl1.AxisChange();
         zedGraphControl1.Invalidate();
        }
        
        //Now you call the function draw every 20 ms using a Timer for example
        private void timer1_Tick(object sender, EventArgs e)
                {
                    draw(data[xValue]);
                }
