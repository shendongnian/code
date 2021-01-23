        public ICollection<ExpandoString> StringExpando
        {
            get
            {
                // ReSharper disable ForCanBeConvertedToForeach
                for (var i = 0; i < _strings.Count; i++)
                // ReSharper restore ForCanBeConvertedToForeach
                {
                    _strings[i].FK = Id;
                    _strings[i].TableName = TableName;
                }
                //using for as we don't want to enumerate the bag
                return _strings.List;
            }
        }
