    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
        Format.Native,
        IsInvariantToDuplicates = false,
        IsInvariantToNulls = true,
        IsInvariantToOrder = true,
        IsNullIfEmpty = true,
        Name = "SumReal")]
    public struct SumReal
    {
        private Single sum;
        public void Init()
        {
            sum = 0;
        }
        public void Accumulate(SqlSingle Value)
        {
            if (!Value.IsNull)
            {
                sum += (Single)Value;
            }
        }
        public void Merge(SumReal Group)
        {
            sum += (Single)Group.sum;
        }
        public SqlSingle Terminate()
        {
            // Put your code here
            return sum;
        }
    }
