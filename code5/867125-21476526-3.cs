            //list with 8 elements
            var eight = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            //remove one element
            eight.RemoveAt(0);
            eight.TrimExcess();
            Assert.Equal(7, seven.Count);
            Assert.Equal(8, eight.Capacity); //capacity is still 8, array was NOT trimmed
