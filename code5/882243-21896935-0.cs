        double[,] arrayTemp = new double[line.Length, 2];
        for (int i = 0; i < line.Length; i++)
        {
            string lines = reader2.ReadLine();
            var data = lines.Split(',');
            
            GlobalDataClass.dDataArray[i, 0] = double.Parse(data[0]);
            GlobalDataClass.dDataArray[i, 1] = double.Parse(data[1]);
        }
        Array.Copy(arrayTemp, GlobalDataClass.dDataArray, line.Length); //error the name "arrayTemp" does not exist in the current context.
        
