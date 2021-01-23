    public class ImportCommodityCode : IRule
    {
        public bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && 
                   value.Length == 10 && 
                   !value.AsEnumerable().Any (t => !char.IsDigit(t));
        }
    }
