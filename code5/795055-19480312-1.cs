        public IEnumerable<string> ReadLines(string filename) {
            FileStream logFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader logFileReader = new StreamReader(logFileStream)) {
                while (!logFileReader.EndOfStream) {
                    yield return logFileReader.ReadLine();
                    }
                }
            }
