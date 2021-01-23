        using System.IO;
        public bool findText(string filePath, string wordToFind)
        {
            string content = File.ReadAllText(filePath);
            if (content.Contains(wordToFind))
            {
                return true;
            }
            return false;
        }
