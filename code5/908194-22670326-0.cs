        foreach (var file in d.GetFiles("*.xml"))
        {
            string test = getValuesOneFile(file.ToString());
            result.Add(test);
            result.Add(Environment.NewLine);
            Console.WriteLine(test);
            Console.ReadLine();
        }
        File.WriteAllLines(filepath + @"\MapData.txt", result);
