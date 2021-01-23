    class MyListSorter : IComparer<myObject>
    {
        public int Compare(myObject x, myObject y)
        {
            if (x.Num < y.Num) return 1;
            if (x.Num > y.Num) return -1;
            return 0;
        }
    }
    myList.Sort(new MyListSorter());
