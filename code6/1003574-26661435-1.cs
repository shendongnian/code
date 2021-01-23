    using System.Text.RegularExpressions;
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
                const string pattern = @"\[(.*?)\]";
                var matches = Regex.Matches(System.IO.File.ReadAllText(path), pattern);
                foreach (Match m in matches)
                    System.Console.WriteLine(m.Groups[1]);
            }
        }
    }
