        private static void restoreFromBackup(string chosenFile)
        {
            string sourceDirectory = @"G:\temp\test2";
            string destinationDirectory = @"G:\temp\test2\test3";
            string pattern = @"(\.bin|\.hid)$";
            // Create new directory in which to move existing .bin and .hid files on the PC
            Directory.CreateDirectory(destinationDirectory);
            Array.ForEach(Directory.GetFiles(destinationDirectory), File.Delete);
            var files = Directory.GetFiles(sourceDirectory)
                .Where(x => Regex.IsMatch(x, pattern, RegexOptions.IgnoreCase))
                .Select(x => x)
                .ToArray();
            Array.ForEach(files, file => 
            {
                Console.WriteLine(file);
                File.Move(file, Path.Combine(destinationDirectory, Path.GetFileName(file))); 
            });
        }
