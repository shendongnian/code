        [TestMethod]
        public void ContractsMatch()
        {
            // Arrange
            string expectedWsdl = this.GetContractString<IFooService>();
            // Act
            string actualWsdl = this.GetContractString<IAsyncFooService>();
            // Assert
            Assert.AreEqual(expectedWsdl, actualWsdl);
        }
        private string GetContractString<TContract>()
        {
            ContractDescription description = ContractDescription.GetContract(typeof(TContract));
            WsdlExporter wsdlExporter = new WsdlExporter();
            wsdlExporter.ExportContract(description);
            if (wsdlExporter.Errors.Any())
            {
                throw new InvalidOperationException(string.Format("Failed to export WSDL: {0}", string.Join(", ", wsdlExporter.Errors.Select(e => e.Message))));
            }
            MetadataSet wsdlMetadata = wsdlExporter.GetGeneratedMetadata();
            string contractStr;
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
            {
                wsdlMetadata.WriteTo(xmlWriter);
                contractStr = stringBuilder.ToString();
            }
            return contractStr;
        }
