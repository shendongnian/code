    public sealed class ControlledQueryableAttribute : QueryableAttribute
    {
        public ControlledQueryableAttribute()
        {
            this.AllowedArithmeticOperators = AllowedArithmeticOperators.None;
            this.AllowedFunctions = AllowedFunctions.AllFunctions;
            this.AllowedLogicalOperators = AllowedLogicalOperators.All;
            this.AllowedQueryOptions =
                AllowedQueryOptions.Skip |
                AllowedQueryOptions.Top |
                AllowedQueryOptions.Filter |
                AllowedQueryOptions.OrderBy |
                AllowedQueryOptions.InlineCount |
                AllowedQueryOptions.Select |
                AllowedQueryOptions.Expand;
            this.MaxTop = 100;
        }
    }
