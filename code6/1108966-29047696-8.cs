        [Test]
        public void FieldTagTestUsingIndex()
        {
            var res = SearchPositionUsingIndex(_tagList, "PT");
            res.ToString().Should().Be("ID2");
        }
