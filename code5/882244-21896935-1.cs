    //Array is now declared in an accessible scop
    double[,] arrayTemp;
    string filename = openFileDialog1.FileName;
    string[] line = File.ReadAllLines(filename);
    using (var reader2 = File.OpenText(@filename))
    {
        for (int i = 0; i < line.Length; i++)
        {
            string lines = reader2.ReadLine();
            arrayTemp = new double[line.Length, 2];
            var data = lines.Split(',');
            GlobalDataClass.dDataArray[i, 0] = double.Parse(data[0]);
            GlobalDataClass.dDataArray[i, 1] = double.Parse(data[1]);
        }
        Array.Copy(arrayTemp, GlobalDataClass.dDataArray, line.Length); //error the name "arrayTemp" does not exist in the current context.
    } 
