    String strPath = "C:\\Zebra";
                String zplStart = "CT~~CD,~CC^~CT~\r\n^XA\r\n^MMT\r\n^PW831\r\n^LL0599\r\n^LSO\r\n";
                String zplMiddle = "^FT50,180^BY3^BCN,200,N,N,N^FD"; ///+barcode
                String zplMiddle2 = "^FS\r\n^FT600,145^AAN,30,10,^FH\\^FD";///+barcode 
    
                String zplMiddle3 = "^FS^\r\n^RS8,,800,5^RFW,H^FD";//+RFID
               
                String splend1 = "^FS\r\n^RWH,H^FS\r\n^RR10^FS\r\n^PQ1\r\n^XZ";
                string filePath = strPath + "\\Books" + ".zpl";
    string Prefix="..." //Define tag ID Prefix
    string Sufix =".."//Define tag ID suffix
    RFID ="Prefix"+ barcode +Sufix;
                StreamWriter strw = new StreamWriter(filePath);
                strw.Write(zplStart + zplMiddle + barcode + zplMiddle2 + barcode+ zplMiddle3 + RFID+  splend1); // aseemble the three parts of the zpl code
               
                    string command = "copy " + filePath + " lpt1"; //prepare a string with the command to be sent to the printer
                    // The /c tells cmd that we want it to execute the command that follows, and then exit.
                    System.Diagnostics.ProcessStartInfo sinf = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
    
                    sinf.UseShellExecute = false;
                    sinf.CreateNoWindow = true;
    
                    System.Diagnostics.Process p = new System.Diagnostics.Process(); // new process            
                    p.StartInfo = sinf;//load start info into process. 
                    p.Start(); //start process (send file to printer)
                
               
