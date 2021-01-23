        [Test]
        public void FieldTagTestLinq()
        {
            var res = SearchUsingLinq();
            res.ToString().Should().Be("ID2");
        }
        private object SearchUsingLinq()
        {
            var p = _tagList.SkipWhile(x => x.FieldTag != "PT").Skip(1).FirstOrDefault();
            return p != null ? p.Position : null;
        }
