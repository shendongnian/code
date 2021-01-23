        [Test]
        public void ApplySameLogicToCollectionsCount()
        {
            var receipt = new Receipt();
            var details = new ReceiptDetail();
            var details2 = new ReceiptDetail();
            receipt.Details.Add(details);
            receipt.Details.Add(details2);
            var result = LambdaGeneratorFactory<ICollection<ReceiptDetail>>.Run(detailsCount);
            Assert.IsTrue(result(receipt.Details));
        }
