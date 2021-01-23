            string lines;
            using (var strReader = new StreamReader(@"C:\Users\Влад\Documents\Task1\ConcordanceApplication\Text.txt"))
            {
                lines = strReader.ReadToEnd();
                strReader.Close();
            }
            string[] words = SplitWords(lines);
            foreach (var  word in words)
                Console.WriteLine(word);
