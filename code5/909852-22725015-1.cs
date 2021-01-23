    public enum KPIType
    {
     None = 0,
     KPI_One = 1,  // the value corresponds to the Id column values in KPI table.
     KPI_Two = 2,
     // so on
    }
    
    Dictionary<KPIType, Func<string, string>> kpiProcessors = 
                             new Dictionary<KPIType, Func<string, string>>();
    
    // define all the kpi processor delegates.
    // the delegate will take string line data from the input file and 
    // convert into the Struct object for that KPI and serialize this struct 
    // into JSON.
    // note the output string is not same as the input file string. it is JSON
    // of the structure for the KPI.
    
    kpiProcessors.Add(KPIType.KPI_One, KPIOneDataProcessorMethodName);
    kpiProcessors.Add(KPIType.KPI_Two, KPITwoDataProcessorMethodName);
    
    // KPIOneDataProcessorMethodName is of the form
    public string KPIOneDataProcessorMethodName(string inputFileKpiLineData) 
    {
     struct KPI_One_Struct; 
     // process inputFileKpiLineData to populate KPI_One_Struct
     return JsonConvert.SerializeObject(KPI_One_Struct);
    }
    
    void ProcessFile()
    {
    // actual file processing logic.
    
    do
    {
        KPIType currentKPIType = KPI_One; // read current KPI;
        
        while (string lineData = KPI_Type_Line_Data_From_File)
        {
           Func<string, string> kpiFunc = kpiProcessors[currentKPIType];   
           string jsonKpiStructData = kpiFunc(lineData);
        
           SQLHelper.InsertKpiDataLine(currentKPIType, jsonKpiStructData);
        }
    } while (kpidataisreadfromfile)
