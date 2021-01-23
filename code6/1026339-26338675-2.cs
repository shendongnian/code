    [TestMethod]
        public void LinqDictionary()
        {
            var dict = getDictionary();
            foreach (var item in dict)
            {
                Console.WriteLine("FieldName {0}, LabelName {1} ", item.Key, item.Value);
            }
            
        }
