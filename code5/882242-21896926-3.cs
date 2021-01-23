     string filename = openFileDialog1.FileName;
     string[] line = File.ReadAllLines(filename);
     double arrayTemp=new double[line.Length,2];//declare outside forloop so it available after forloop.
     GlobalDataClass.dDataArray=new double[line.Length,2]; //add this line
     using (var reader2 = File.OpenText(@filename))
     {
       for (int i = 0; i < line.Length; i++)
       {
         string lines = reader2.ReadLine();
         var data = lines.Split(',');         
         GlobalDataClass.dDataArray[i, 0] = double.Parse(data[0]);
         GlobalDataClass.dDataArray[i, 1] = double.Parse(data[1]);
       }
        Array.Copy(arrayTemp, GlobalDataClass.dDataArray, line.Length); 
     }
