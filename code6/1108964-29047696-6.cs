        [Test]
        public void FieldTagTest()
        {
            var res = SearchPosition(_tagList, "PT");
            res.ToString().Should().Be("ID2");
        }
