        [Fact]
        public void Test()
        {
            var data = new List<int> { 3, 4, 5, 7, 8, 10, 11, 12 };
            // data.Sort();
            var groups = new List<string>();
            var startIndex = 0;
            for (var i = 1; i < data.Count; i++)
            {
                if (data[i - 1] == data[i] - 1)
                {
                    continue;
                }
                AddToGroups(groups, startIndex, i, data);
                startIndex = i;
            }
            AddToGroups(groups, startIndex, data.Count, data);
            var result = string.Join(",", groups);
            Assert.Equal("3-5,7,8,10-12", result);
        }
        private static void AddToGroups(List<string> groups, int startIndex, int actualIndex, List<int> data)
        {
            switch (actualIndex - startIndex)
            {
                case 1:
                    groups.Add(data[startIndex].ToString());
                    break;
                case 2:
                    groups.Add(data[startIndex].ToString());
                    groups.Add(data[startIndex + 1].ToString());
                    break;
                default:
                    groups.Add(data[startIndex] + "-" + data[actualIndex - 1]);
                    break;
            }
        }
