        private void SetChartTransparency(Chart chart, string Seriesname)
        {
            bool setTransparent = true;
            int numberOfPoints = 3;          
            chart.ApplyPaletteColors();
            foreach (DataPoint point in chart.Series[Seriesname].Points)
            {
                if (setTransparent)
                    point.Color = Color.FromArgb(0, point.Color);
                else
                    point.Color = Color.FromArgb(255, point.Color);
                numberOfPoints = numberOfPoints - 1;
                if (numberOfPoints == 0)
                {
                    numberOfPoints = 3;
                    setTransparent = !setTransparent;
                }         
            }     
        } 
