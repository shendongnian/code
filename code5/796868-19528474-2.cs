    class Program
    {
        static void Main(string[] args)
        {
            restoreFromBackup("");
        }
        private static void restoreFromBackup(string chosenFile)
        {
            // Create new directory in which to move existing .bin and .hid files on the PC
            if (!Directory.Exists(@"G:\temp\test2\test3"))
            {
                Directory.CreateDirectory(@"G:\temp\test2\test3");
            }
            else
            {
                Array.ForEach(Directory.GetFiles(@"G:\temp\test2\test3"), File.Delete);
            }
            // Move existing .bin and .hid files to the new directory
            string pattern = @"(\.bin|\.hid|\.BIN|.HID)$";
            var files = Directory.GetFiles(@"G:\temp\test2")
                .Where(x => Regex.IsMatch(x, pattern))
                .Select(x => x).ToList();
            foreach (var item in files)
            {
                Console.WriteLine(item);
                string name = item.Substring(item.LastIndexOf("\\") + 1);
                File.Move(item, Path.Combine(@"G:\temp\test2\test3", name));
            }
        }
    }
