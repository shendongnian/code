    string filename = openFileDialog1.FileName;
    var lineCount = 0;
    using (var reader = File.OpenText(@filename))
    {
         string line;
         while ((line = reader.ReadLine()) != null)
         {
              var data = line.Split(',');
              Coordinate coord = new Coordinate();
              coord.x = double.Parse(data[0]);
              coord.y = double.Parse(data[1]);
              GlobalDataClass.dDataArray.Add(coord)
              lineCount++;
         }
         ShowGraphData(lineCount);
    }
