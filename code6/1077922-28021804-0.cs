        Console.Title = "Command Prompt";
                        OperatingSystem os = Environment.OSVersion;
                        Version ver = os.Version;
                        ver.ToString();
                        if (os.VersionString.Equals("Microsoft Windows NT 6.2.9200.0"))
                                {
                                        Console.WriteLine("Microsoft Windows [Version 6.3.9600]");
                                        Console.WriteLine("(c) 2013 Microsoft Corporation. All rights reserved. \n");
                                        goto a;
                                }
            
                        else
    {
           ver_error:
                            Console.WriteLine("Error: OS '" + os.VersionString + "' Missing from libraries, \nnot yet implemented?\n");
                            Console.WriteLine("Available Operating Systems:\nWndows 8.1, Microsoft Windows NT 6.2.9200.0 ");
                            Thread.Sleep(3000);
                            Console.WriteLine("\n\nPress enter to boot Error Protocol, type exit to exit.\n");
                        error_test:
                            string errorProtocol;
                            errorProtocol = Console.ReadLine();
                            if (errorProtocol.Equals("")) 
                                    {
                                        Console.WriteLine("Booting Error Protocol...");
                                        Thread.Sleep(2000);
                                        goto error_report;
                                    }
                            else if (errorProtocol.Equals("exit"))
                                    {
                                        goto end;
                                    }
                            else
                                    {
                                        Console.WriteLine("Not a valid response.");
                                            goto error_test;
                                    }
                        }
            /* C:\Users\18LeunJA dir */
            a:
                        Console.Write("C:\\Users\\18LeunJA>");
                        string userValueFromStart;
                        userValueFromStart = Console.ReadLine();
                        if (userValueFromStart.Equals("exit"))
                                {
                                        goto end;
                                }
                        else if (userValueFromStart.Equals("triggerOSError"))
                        {
                            goto ver_error;
                        }
