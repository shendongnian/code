        [Test]
        public void FindDuplicates()
        {
            _sw.Start();
            for (int i = 0; i < _files.Count; i++) // Compare SourceFileList-Files to themselves
            {
                for (int n = i + 1; n < _files.Count; n++) // Don´t need to do the same comparison twice!
                {
                    if (_files[i].TargetNode.IsFile && _files[n].TargetNode.IsFile)
                        if (_files[i].Hash == _files[n].Hash)
                        {
                            // Do Work
                            _matched++;
                        }
                }
            }
            _sw.Stop();
        }
