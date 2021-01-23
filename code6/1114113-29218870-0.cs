    interface IRoomEntry
    {
        Room RoomToBuild();
    }
    class RoomPlanner
    {
        class RoomEntry<T> : IRoomEntry
            where T : Room, new()
        {
            public Point chance;
            T r;
            public Room RoomToBuild()
            {
                return new T();
            }
        }
        IRoomEntry[] entrys;
        public void Foo()
        {
            entrys = new IRoomEntry[10];
            for (int i = 0; i < entrys.Length; i++)
            {
                entrys[i] = new RoomEntry<RoundRoom>();
            }
        }
    }
