    public sealed class CodeActivityGetEVA : CodeActivity<DateTime>
    {
        public InArgument<int> EventID { get; set; }
        protected override DateTime Execute(CodeActivityContext context)
        {
            return DateTime.Now;
        }
    }
