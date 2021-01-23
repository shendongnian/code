    using DotRas;
    namespace ListVPNConnections
    {
        class Program
        {
            static void Main()
            {
                // VPN adapters are stored in the rasphone.pdk
                // "C:\Users\Me\AppData\Roaming\Microsoft\Network\Connections\Pbk\rasphone.pbk"
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                              @"\Microsoft\Network\Connections\Pbk\rasphone.pbk";
                RasPhoneBook pbk = new RasPhoneBook();
                pbk.Open(path);
                foreach (RasEntry entry in pbk.Entries)
                   System.Console.WriteLine((entry.Name));
            }
        }
    }
