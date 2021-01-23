    class Program {
      public static void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader, string seperator) {
        ...code here
      }
      public static void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader) {
        WriteToFile(dataSource, fileOutputPath, firstRowIsColumnHeader, ";");
      }
      public static void WriteToFile(DataTable dataSource, string fileOutputPath) {
        WriteToFile(dataSource, fileOutputPath, false, ";");
      }
    }
