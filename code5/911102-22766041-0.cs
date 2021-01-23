        [Test]
        public void Allbum_Search_Test()
        {
            var searchText = "TestA";
            var list1 = new SortedList<string, Albums>
            {
                {"TestAlbum1", new Albums("TestAlbum1","SomeDate")},
                {"TestAlbum2", new Albums("TestAlbum2","SomeDate")},
                {"OtherAlbum2", new Albums("OtherAlbum","SomeDate")}
            };
            var results = list1.Where(pair => pair.Key.Contains(searchText));
            Assert.That(results.Count(), Is.EqualTo(2));
        }
