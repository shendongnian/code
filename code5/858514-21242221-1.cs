        public IDDesc GetIDDescByID(int ID)
        {
            IDDesc toFind = new IDDesc();
            toFind.ID = ID;
            //List Items must be sorted!
            list.Sort();
            int foundIndex = list.BinarySearch(toFind);
            if (foundIndex > -1)
                toFind = list[foundIndex];
            return toFind;
        }
