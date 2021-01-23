    /// <summary>
    /// Token provider that uses a DataProtector to generate encrypted tokens
    /// </summary>
    public class DataProtectorTokenProvider : ITokenProvider {
        public DataProtectorTokenProvider(IDataProtector protector)
