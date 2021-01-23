    using System.IO;
    using System;
    class Program
    {
        static void Main()
        {
            short byte1 = 192;
            short byte2 = 168;
            short byte3 = 0;
            short byte4 = 1;
         
            uint IP =   (uint)(byte1 << 24) 
                      | (uint)(byte2 << 16) 
                      | (uint)(byte3 <<  8) 
                      | (uint) byte4 ;
         
            uint step_size = 90000000;
    
            while( IP != 0xFFFFFFFF ) {
                
                Console.WriteLine(
                      ((IP >> 24) & 0xFF) + "." +
                      ((IP >> 16) & 0xFF) + "." +
                      ((IP >> 8 ) & 0xFF) + "." +
                      ( IP        & 0xFF)
                    );
         
                 // if (0xFFFFFFFF - IP) < step_size then we can't 
                 // add step_size to IP due to integer overlow
                 // which means that we have generated all IPs and 
                 // there isn't any left that equals IP + step_size
                 if( (0xFFFFFFFF - IP) < step_size ) {
                     return;
                 }
         
                 IP += step_size; // next ip address
            }
        }
    }
