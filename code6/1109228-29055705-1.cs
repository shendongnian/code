        [SetUp]
        public void TestStup()
        {
            _sw = new Stopwatch();
            _files = new List<File>();
            int duplicateHashes = 10000;
            int triplicateHashesCount = 900;
            int randomCount = 1000;
            int nonFileCount = 5000;
            for (int i = 0; i < duplicateHashes; i++)
            {
                var hash = i % (duplicateHashes / 2);
                _files.Add(new File {Id = i, Hash = hash.ToString(), TargetNode = new Node {IsFile = true}});
            }
            for (int i = 0; i < triplicateHashesCount; i++)
            {
                var hash = int.MaxValue - 100000 - i % (triplicateHashesCount / 3);
                _files.Add(new File {Id = i, Hash = hash.ToString(), TargetNode = new Node {IsFile = true}});
            }
            for (int i = 0; i < randomCount; i++)
            {
                var hash = int.MaxValue - i;
                _files.Add(new File { Id = i, Hash = hash.ToString(), TargetNode = new Node { IsFile = true } });
            }
            for (int i = 0; i < nonFileCount; i++)
            {
                var hash = i % (nonFileCount / 2);
                _files.Add(new File {Id = i, Hash = hash.ToString(), TargetNode = new Node {IsFile = false}});
            }
            _matched = 0;
        }
