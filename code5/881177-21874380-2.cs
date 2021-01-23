            string filename = openFileDialog1.FileName;
            var lineCount = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (GlobalDataClass.dDataArray.GetLength(0) == lineCount)
                {                
                    double[,] newTemp = GlobalDataClass.dDataArray;
                    int increaseLenght = newTemp.Length + 1000;
                    GlobalDataClass.dDataArray = new double[increaseLenght, 2];
                    Array.Copy(newTemp, GlobalDataClass.dDataArray, newTemp.LongLength);
                }
    
                var data = line.Split(',');
                GlobalDataClass.dDataArray[lineCount, 0] = double.Parse(data[0]);
                GlobalDataClass.dDataArray[lineCount, 1] = double.Parse(data[1]);
                lineCount++;
            }
