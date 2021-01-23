    [Test]
        public void CsvStreamsToCsvStream()
        {
          using(Stream fstrm = 
                    Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(@"Tests.TestFiles.Test.csv"))
          {
            var decompressor =
              new MemoryDecompresser(fstrm, "Test.csv");
            var results = decompressor.GetStreams();
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(results.First().Key, "Test.csv");
    
          }
        }
