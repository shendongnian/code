    namespace less
    {
       public partial class MainWindow : Window
       {
            ...
    
           // Now these are global class level variable...
           // But again, don't do that.....
           private StreamReader inputFile;
           StreamWriter outputFile;
           StreamWriter logFile;
    
           private static string filename;
    
            ...
       }
