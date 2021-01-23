    double n;
    foreach (string line in File.ReadAllLines("test.txt"))
        {
            string[] fields = line.Split(',');
            bool ageIsNumeric = double.TryParse(fields[0], out n);
            bool districtIsNumeric = double.TryParse(fields[3], out n);
            if(!ageIsNumeric || !districtIsNumeric)
                continue;
            ageData[i] = int.Parse(fields[0]);          
            districtDataA[i] = int.Parse(fields[3]);
