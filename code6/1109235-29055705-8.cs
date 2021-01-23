        [Test]
        public void FindDuplicatesHashParallel()
        {
            _sw.Start();
            
            var lookup = _files.Where(f => f.TargetNode.IsFile).ToLookup(f => f.Hash);
            _matched = lookup.AsParallel().Where(g => g.Count() > 1).Sum(g => 1);
            _sw.Stop();
        }
