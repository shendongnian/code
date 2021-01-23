     foreach (object item in listBox1.SelectedItems)
            {
                string curItem = item.ToString();
                var parts = curItem.Split("{}XY=, ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var xCoord = CultureCheck(parts[0]);
                var yCoord = CultureCheck(parts[1]);
                var point = new PointF(xCoord, yCoord);
                CloudEnteringAlert.pointtocolor.Add(point);
                pictureBox1.Invalidate();
            }       
        private double CultureCheck(string input)
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
           return double.Parse(input, NumberStyles.Any, ci);
        }
