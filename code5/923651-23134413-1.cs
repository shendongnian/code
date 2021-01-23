     string[] allLines = System.IO.File.ReadAllLines(@"yourCVSPath.csv");
     foreach(string sLine in allLines)
     {
             string[] arrLine = sLine.Split(new char[] { ',' }); // or ';' according to provided data
              if (arrLine.Length == 5)
              {
                   string sDevice = arrLine[0];
                   string sLatitude = arrLine[1];
                   string sLongitude = arrLine[2];
                   string sSpeed = arrLine[3];
                   string sTime = arrLine[4];
                   ShapeLayer sl = new ShapeLayer("Marker");
                   wpfMap.Layers.Add(sl);
                   marker.Width = marker.Height = 20;
                   marker.ToolTip = sLine; //[needs to contain Device;Latitude;Longitude;Speed;Time]
                   sl.Shapes.Add(marker);
                   ShapeCanvas.SetLocation(marker, new System.Windows.Point(sLongitude, sLatitude)); //[needs to contain Longitude,Latitude]
              }
      }
