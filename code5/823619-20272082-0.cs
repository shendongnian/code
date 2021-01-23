        private Range CodeUnderTest(Range rowSelected, Worksheet worksheet)
        {
            int index = rowSelected.Row;
            var range = worksheet.Rows.get_Range(index);
            return (Range) range;
        }
        [TestMethod]
        public void MySampleTest()
        {
            var moqRowSelected = new Mock<Range>();
            const int row = 1;
            moqRowSelected.SetupGet(x => x.Row).Returns(row);
            var moqRows = new Mock<Range>();
            moqRows.Setup(x => x.get_Range(It.Is<object>( (i) => (int) i==row),It.IsAny<object>())).Returns(moqRowSelected.Object);
            var mockWorksheet = new Mock<Worksheet>();
            mockWorksheet.SetupGet(w => w.Rows).Returns(moqRows.Object);
            var result = CodeUnderTest(moqRowSelected.Object, mockWorksheet.Object);
            Assert.IsNotNull(result);
        }
