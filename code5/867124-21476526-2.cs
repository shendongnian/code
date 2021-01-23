            //list with 7 elements
            var seven = new List<int>(new[] {1, 2, 3, 4, 5, 6, 7});
            seven.TrimExcess();
            Assert.Equal(7, seven.Capacity);
            Assert.Equal(7, seven.Count);
