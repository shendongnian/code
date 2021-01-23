    public class SomeClass: ISomeInterface
    {
        private IStrategyResolver strategyResolver;
        public SomeClass(IStrategyResolver stratResolver)
        {
            this.strategyResolver = stratResolver;
        }
        public void Process(SomeDto dto)
        {
            IActionHandler actionHanlder = this.strategyResolver.Resolve<IActionHandler>(dto.SomeProperty);
            actionHanlder.Handle(dto);
        }
    }
