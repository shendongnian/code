    interface IMode { }
    class FirstMode:IMode { }
    class SecondMode : IMode { }
    class ThirdMode : IMode { }
    class ViewModel
    {
        public IMode Mode { get; private set; }
    }
