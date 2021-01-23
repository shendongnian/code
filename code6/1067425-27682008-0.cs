    public CsvParser()
    {
        Task[] LoadData = new Task[3]
        {
            Task.Factory.StartNew(
                () => 
                    {
                        IEnumerable<MachineDetail> Machines = GetCsvContents<MachineDetail>("MachineDetail*.csv");
                        this.MachineData.AddRange(Machines);
                    }
                ),
 
            Task.Factory.StartNew(
                () => 
                    {
                        IEnumerable<SiteDetail> Sites = GetCsvContents<SiteDetail>("SiteDetail*.csv");
                        this.SiteData.AddRange(Sites);
                    }
                ),
 
            Task.Factory.StartNew(
                () => 
                    {
                        IEnumerable<KeyDetail> Keys = GetCsvContents<KeyDetail>("_keysheets_*.csv");
                        this.KeyData.AddRange(Keys);
                    }
                )
        };
 
        Task.WaitAll(LoadData);
    }
 
    private List<T> GetCsvContents<T>(string CsvFileName)
    {
        List<T> ReturnContents = new List<T>();
     
        FileInfo[] CsvFiles = ResourceDirectory.GetFiles(CsvFileName, SearchOption.TopDirectoryOnly);
 
        foreach (FileInfo CsvFile in CsvFiles)
        {
            using (CsvReader ReadCsv = new CsvReader(new StreamReader(CsvFile.FullName)))
            {
                ReturnContents.AddRange(ReadCsv.GetRecords<T>());
            }
        }
 
        return ReturnContents;
    }
