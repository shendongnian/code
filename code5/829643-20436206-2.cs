    namespace less
    {
       public partial class MainWindow : Window
       {
            ...
    
           // Now these are global class level variables...
           // But again, don't do that.....
           private StreamReader inputFile;
           private StreamWriter outputFile;
           private StreamWriter logFile;
    
           private static string filename;
    
            ...
       }
