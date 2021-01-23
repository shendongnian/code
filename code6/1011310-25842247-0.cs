    delegate string ExtractValueDelegate<T>(T obj);
    public static void WriteCSVData<T>(this T[,] data,ExtractValueDelegte<T> extractor , StreamWriter sw) { ... }
    // calling the method
     myData.WriteCSVData(sw, d => d.Magnitude.ToString());
   
