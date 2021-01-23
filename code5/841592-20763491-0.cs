        [Test]
        public void ReadAllLines()
        {
            var streamReader = new StreamReader(File.Open(@"d:\test.test", FileMode.Open, FileAccess.Read));
            var line = string.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                // do stuff
            }
        }
