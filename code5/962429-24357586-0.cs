    public sealed class SymbolMap : CsvClassMap<Symbol>
    {
        public SymbolMap()
        {
            Map(m => m.nazwa).Name("Company Name");
            Map(m => m.symbol).Name("Stock Symbol");
        }
    }
