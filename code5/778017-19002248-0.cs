    private List<MappingData> GetData(string filename) {
        List<MappingData> data = new List<MappingData>();
        int NumRow = 0;
        MappingData mpName = new MappingData();
        MappingData mpPhone = new MappingData();
        MappingData mpCity = new MappingData();
        string fullPath = GetFilePath(filename);
        StreamReader reader = new StreamReader(fullPath);
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            if (!String.IsNullOrWhiteSpace(line)) {
                string[] values = line.Split(',');
                if (NumRow == 0) {
                    mpName.ColumnName = values[0];
                    mpPhone.ColumnName = values[1];
                    mpCity.ColumnName = values[2];
                    NumRow = 1;
                } else {
                    mpName.Data.Add(values[0]);
                    mpPhone.Data.Add(values[1]);
                    mpCity.Data.Add(values[2]);
                }
            }
        }
        data.Add(mpName);
        data.Add(mpPhone);
        data.Add(mpCity);
        return data;
    }
