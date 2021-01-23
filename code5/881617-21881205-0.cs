            static void Main(string[] args)
            {
                string check = @"324214234\r\n";
                RegistryKey regKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\MyRegKey\\Settings");
                regKey.SetValue("ReceiveSplChar", @"\r\n");
                string value = regKey.GetValue("ReceiveSplChar").ToString();
                if (check.Contains(value))
                    Console.WriteLine("TRUE");
            }
