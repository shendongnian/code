      private void Form1_Activated(object sender, EventArgs e)
            {  
               //Added some point just for an  example
                chart1.Series["Series1"].Points.AddXY(1, 1);
                chart1.Series["Series1"].Points.AddXY(2, 2);
                chart1.Series["Series1"].Points.AddXY(3, 3);
                chart1.Series["Series1"].XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            }
