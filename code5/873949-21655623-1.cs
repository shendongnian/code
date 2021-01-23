    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion");
            foreach (var v in key.GetSubKeyNames())
            {
                RegistryKey key1 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\" + v);
                foreach ( var v1 in key1.GetSubKeyNames())
                {
                    if (v1 == "{00EC8ABC-3C5A-40F8-A8CB-E7DCD5ABFA05}")
                    Console.WriteLine(key1);
                }
            }
        }
    }
