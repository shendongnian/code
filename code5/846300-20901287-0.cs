    static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select your option: 1 for Write, 2 for Read, 3 for Search, others for exit");
                int flag = Convert.ToInt32(Console.ReadLine());
                if (flag != 1 && flag != 2 && flag != 3) break;
                switch (flag)
                {
                    case 1:
                        {
                            StreamWriter SW = new StreamWriter(@"C:\test.txt");
                            while (true)
                            {
                                Console.WriteLine("Enter some value for inset into text file, 0 for exit\n");
                                string temp = Console.ReadLine();
                                if (temp != "0")
                                {
                                    SW.WriteLine(temp);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            //SW.Dispose();
                            SW.Close();
                            break;
                        }
                    case 2:
                        {
                            StreamReader SR = new StreamReader(@"C:\test.txt");
                            while (true)
                            {
                                Console.WriteLine(SR.ReadLine());
                                if (SR.EndOfStream == true)
                                    break;
                            }
                            SR.Dispose();
                            SR.Close();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("entre ur value:\t");
                            string value = Console.ReadLine();
                            StreamReader SR = new StreamReader(@"C:\test.txt");
                            bool flg = false;
                            while (true)
                            {
                                if (value == SR.ReadLine())
                                {
                                    Console.WriteLine(value + " was found in ur text");
                                    flg = true;
                                    break;
                                }
                                if (SR.EndOfStream == true)
                                    break;
                            }
                            if (flg != true)
                            {
                                Console.WriteLine("Sorry not found");
                            }
                            SR.Dispose();
                            SR.Close();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
