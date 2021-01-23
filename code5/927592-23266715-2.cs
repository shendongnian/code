    public class Formula : Operand
    {
        public List<Operand> InnerOperands { get; set; }
        protected internal override void AddPropertiesToObject(dynamic o)
        {
            foreach (var op in InnerOperands)
            {
                op.AddPropertiesToObject(o);
            }
        }
    }
