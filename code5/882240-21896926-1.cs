     double[,] arrayTemp;//declare outside forloop so it available after forloop.
     string filename = openFileDialog1.FileName;
     string[] line = File.ReadAllLines(filename);
     using (var reader2 = File.OpenText(@filename))
     {
       for (int i = 0; i < line.Length; i++)
       {
         string lines = reader2.ReadLine();
         var data = lines.Split(',');
         arrayTemp = new double[line.Length, 2];
         GlobalDataClass.dDataArray[i, 0] = double.Parse(data[0]);
         GlobalDataClass.dDataArray[i, 1] = double.Parse(data[1]);
       }
        Array.Copy(arrayTemp, GlobalDataClass.dDataArray, line.Length); 
     }
