    using System;
    using System.IO.Ports;
    
    namespace RelayConsole
    {
        class Program
        {
            public static SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
    /* Replace COM5 with your COM port, 9600 with baud rate of your board, parity and bits as well as per your device documentation */
            
            static void Main(string[] args)
            {
                SerialProgram();
            }
    
            static void SerialProgram()
            {
                try
                {
                    port.Open();
                    port.Write("RELx.ON"); /* You can pass any command as per your documentation in port.Write */
                    System.Threading.Thread.Sleep(3000);
                    port.Write("RELx.OFF");
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    if(ex is System.IO.IOException)
                    {
                        Console.WriteLine("Port Exception: " + ex.ToString());
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("General Exception: " + ex.ToString());
                        Console.ReadLine();
                    }
                }
            }
        }
    }
