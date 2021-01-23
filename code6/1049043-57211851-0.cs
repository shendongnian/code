    public enum Sequence
    {
        [Description("sequence__name__goes__here")]
        ClientNr,
        [Description("another__sequence__name")]
        OrderNr,
    }
    public static class MyDbContextExtensions
    {
        public static int NextValueForSequence(this MyDbContext pCtx, Sequence pSequence)
        {
            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            var sequenceIdentifier = pSequence.GetType()
                        .GetMember(pSequence.ToString())
                        .First()
                        .GetCustomAttribute<DescriptionAttribute>()
                        .Description;
            pCtx.Database.ExecuteSqlCommand($"SELECT @result = (NEXT VALUE FOR [{sequenceIdentifier}]);", result);
            return (int)result.Value;
        }
    }
