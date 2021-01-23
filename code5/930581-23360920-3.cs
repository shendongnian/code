    public struct ConversionDetails
    {
        public readonly string Unit1;
        public readonly string Unit2;
        public readonly Decimal Ratio;
        public ConversionDetails(string[] line)
        {
            Unit1 = line[0];
            Unit2 = line[1];
            Ratio = Decimal.Parse(line[2]);
        }
    }
    var rows = File.ReadAllLines("ConversionsDefault.txt").Select(l => new ConversionDetails(l.Split('|'))).ToArray();
