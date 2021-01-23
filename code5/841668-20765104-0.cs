    using System;
    using System.Management; 
 
    class Application
    {
        public static void Main()
        {
            SelectQuery query = new SelectQuery( "select * from win32_logicaldisk where drivetype=5" );
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
 
            foreach( ManagementObject mo in searcher.Get() )
            {
              // If both properties are null I suppose there's no CD
                 if( ( mo["volumename"] != null ) || ( mo["volumeserialnumber"] != null ) )
                 {
                     Console.WriteLine( "CD is named: {0}", mo["volumename"] );
                     Console.WriteLine( "CD Serial Number: {0}", mo["volumeserialnumber"] );
                 }
                 else
                 {
                     Console.WriteLine( "No CD in Unit" ); // Here you can make sure there is no disk.
                 }
            }
 
            // Here to stop app from closing
            Console.WriteLine( "\nPress Return to exit." );
            Console.Read();
       }
    }
