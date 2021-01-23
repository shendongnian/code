        public static void TestListContainerJson()
        {
            var list = new ListContainer<int>();
            list.Add(101);
            list.Add(102);
            list.Add(103);
            var json = JsonConvert.SerializeObject(list);
            var newList = JsonConvert.DeserializeObject<ListContainer<int>>(json);
            Debug.Assert(list.SequenceEqual(newList)); // No assert.
        }
