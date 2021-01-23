    class Fancy1
    {
        public double level1;
        public bool isEnable1;
        public double level2;
        public bool isEnable2;
        public double level3;
    }
    public class FieldWrapper
    {
        private Action<double> _levelSetter;
        private Func<double>   _levelGetter;
        private Action<bool>   _enableSetter;
        private Func<bool>     _enableGetter;
        public double level     { get { return _levelGetter();  } set { _levelSetter(value);  }}
        public bool   isEnabled { get { return _enableGetter(); } set { _enableSetter(value); }}
        internal FieldWrapper(Func<double> levelGetter, Action<double> levelSetter, Func<bool> enableGetter, Action<bool> enableSetter)
        {
            _levelGetter = levelGetter;
            _levelSetter = levelSetter;
            _enableGetter = enableGetter;
            _enableSetter = enableSetter;
        }
    }
    abstract class FancyWrapper
    {
        public FieldWrapper[] Fields { get; protected set; }
    }
    class Fancy1Wrapper : FancyWrapper
    {
        private Fancy1 _fancy1;
        public Fancy1Wrapper(Fancy1 fancy1)
        {
            _fancy1 = fancy1;
            this.Fields = new[] { new FieldWrapper(() => fancy1.level1, level => _fancy1.level1 = level, () => _fancy1.isEnable1, enable => _fancy1.isEnable1 = enable),
                                  new FieldWrapper(() => fancy1.level2, level => _fancy1.level2 = level, () => _fancy1.isEnable2, enable => _fancy1.isEnable2 = enable), };
        }
    }
