    public CalculatorOutputModel CalculateXml(CalculatorInputModel input)
    {
        using (var ms = Serializer.Serialize(input))
        {
            ms.Position = 0;
            using (var rawResult = Channel.RawGetFrbXmlOutputs(ms))
            {
                var result = Parser.Parse(rawResult);
                return result;
            }
        }
    }
