        public FileInfo Current
        {
            get
            {
                try
                {
                    //FileInfo fi = new FileInfo(RankedList[position].MediaUrl);
                    FileInfo fi = new FileInfo(RankedList[rnd.Next(RankedList.Count)].MediaUrl);
                    return fi;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
