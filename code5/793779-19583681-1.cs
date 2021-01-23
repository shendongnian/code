        static string myfile1 = @"C:\inbox\mytest.txt";
        static string myfile2 = @"C:\inbox\test2.txt";
        //files from server        
        static string myServerfile = @"C:\Users\me\Documents\file_client\bin\Debug\test.csv";
        static string myServerfile1 = @"C:\Users\RH-T3\Documents\file_client\bin\Debug\test111.txt";
     public static void Main(string[] args)
		{	
                try
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("Downloading test.csv");
                            string fileName = "test.csv";
                            Console.WriteLine("Client starts...");
                            //args[0] = Console.ReadLine();
                            file_client client = new file_client(args);
                            Console.WriteLine("efter file_client...");
                            NetworkStream serverStream = client.clientSocket.GetStream();
                            LIB.writeTextTCP(serverStream, fileName);
                            long rest = long.Parse(LIB.readTextTCP(serverStream));
                            byte[] inStream = new byte[rest];
                            while (rest != 0)
                            {
                                rest = rest - serverStream.Read(inStream, 0, inStream.Length);
                                Console.WriteLine("REST: " + rest);
                            }
                            FileStream fs = new FileStream(fileName, 							FileMode.Create);
                            fs.Write(inStream, 0, inStream.Length);
                            {
                                fs.Close();
                                serverStream.Close();
                            }
                            if (File.Exists(myfile1))
                            {
                                File.Delete(myfile1);
                            }
                            File.Move(myServerfile, myfile1);
                            Console.WriteLine("Moved");
                            System.Threading.Thread.Sleep(500);
                        } 
                         else  
                           {
                            Console.WriteLine("Downloading .txt file");
                            string fileName = "test111.txt";
                            Console.WriteLine("Client starts...");
                            //args[0] = Console.ReadLine();
                            file_client client = new file_client(args);
                            Console.WriteLine("efter file_client...");
                            NetworkStream serverStream = client.clientSocket.GetStream();
                            LIB.writeTextTCP(serverStream, fileName);
                            long rest = long.Parse(LIB.readTextTCP(serverStream));
                            byte[] inStream = new byte[rest];
                            while (rest != 0)
                            {
                 rest = rest - serverStream.Read(inStream, 0, inStream.Length);
                                Console.WriteLine("REST: " + rest);
                            }
                            FileStream fs = new FileStream(fileName, 							FileMode.Create);
                            fs.Write(inStream, 0, inStream.Length);
                            {
                                fs.Close();
                                serverStream.Close();
                            }
                            if (File.Exists(myfile2))
                            {
                                File.Delete(myfile2);
                            }
                            File.Move(myServerfile1, myfile2);
                            Console.WriteLine("Moved");
                            System.Threading.Thread.Sleep(500);
                        }
                    }
			}
                    catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Cannot be DONE!");
                } 
