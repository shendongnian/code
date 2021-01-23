        public IEnumerable<string> AncenstoryEnum
        {
            get { return AncenstoryReversed.Reverse(); }
        }
        private IEnumerable<string> AncenstoryReversed
        {
            get
            {
                TableSearchNode ancestor = ParentNode;
                while (ancestor != null)
                {
                    yield return ancestor.tbl;
                    ancestor = ancestor.ParentNode;
                }
            }
        }
