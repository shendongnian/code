        private string ReadFromResponseFiles(Stream[] inputs)
        {
            var rawContent = new StringBuilder();
            foreach (var stream in inputs)
            {
                using (stream)
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        rawContent.Append(streamReader.ReadToEnd());
                    }
                }
            }
            return rawContent.ToString();
        }
        [Test]
        public void Can_read_files()
        {
            var file1 = new MemoryStream(Encoding.UTF8.GetBytes("Foo"));
            var file2 = new MemoryStream(Encoding.UTF8.GetBytes("Bar"));
            var result = ReadFromResponseFiles(new[] { file1, file2 });
            Assert.AreEqual("FooBar", result);
            file1.Dispose();
            file2.Dispose();
        }
    }
