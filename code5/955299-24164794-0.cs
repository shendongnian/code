    public void PassList(List<DateTime> myList)
        {
            lock (obj)
            {
                _list = myList;
            }
        }
