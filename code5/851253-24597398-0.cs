        [Test]
        public void ServiceTest3()
        {
            // setup
            var expected = new Outer()
            {
                Name = "outerName",
                Inner = new Inner()
                {
                    Name = "innerName",
                    Value = "value2"
                }
            };
            var expectedLikeness = expected.AsSource().OfLikeness<Outer>()
                .WithInnerLikeness(d => d.Inner, s => s.Inner)
                ;
            var sut = new Service();
            // exercise sut
            var actual = sut.Method();
            // verify
            expectedLikeness.ShouldEqual(actual);
        }
