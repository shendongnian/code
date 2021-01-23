        public bool MoveNext()
        {
            position++;
            return (position < RankedList.Count);
            //position = rnd.Next(RankedList.Count);
            //return true;
        }
