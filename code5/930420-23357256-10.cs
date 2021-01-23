    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            
            String ipString = "192.168.0.1";
            
            String[] ipBytes = ipString.Split('.');
            
            uint byte1 = Convert.ToUInt32(ipBytes[0]);
            uint byte2 = Convert.ToUInt32(ipBytes[1]);
            uint byte3 = Convert.ToUInt32(ipBytes[2]);
            uint byte4 = Convert.ToUInt32(ipBytes[3]);
         
            uint IP =   (byte1 << 24) 
                      | (byte2 << 16) 
                      | (byte3 <<  8) 
                      |  byte4 ;
         
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
