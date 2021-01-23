    [TestMethod]
        public void ListAndArrayTest()
        {
            int[] array = GetArray();
            Debug.WriteLine("IsFixedSize {0}, Elements {1}", array.IsFixedSize, array.Length);
    // This will print IsFixedSize True, Elements 35
        }
        private int[] GetArray()
        {
            List<int> localList = new List<int>();
            for (int i = 0; i < 35; i++)
            {
                localList.Add(i);
            }
            Debug.WriteLine("Capacity {0}, Element Count {1}", localList.Capacity, localList.Count);
            // This will print Capacity **64**, Element Count **35**
            return localList.ToArray();
        }
