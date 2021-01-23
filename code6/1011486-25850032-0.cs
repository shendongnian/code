     void scaleAnnotation(Annotation A)
     {
         ChartArea CA = chart1.ChartAreas[0];// pick your chartarea..
         A.AxisX = CA.AxisX;                 // .. and axis!
         int N = S1.Points.Count;            // S1 being your Series !
         // to keep the label width constant the chart's width must be considered
         // 60 is my 'magic' number; you must adapt for your chart's x-axis scale!
         double xFactor = 60 * N / chart1.Width;   
         A.Width = 1 * xFactor ;
         A.X = VA.X - A.Width / 2;    
     }
