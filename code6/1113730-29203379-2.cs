    public interface ICake
    {
        void Interact(IBox box);
        bool IsPacked { get; }
        bool IsDecorated { get; }
        string NameOfCake { get; set; }
    }
    public class ChocolateCake : ICake
    {
        private bool _isPacked;
        private bool _isDecorated;
        private string _nameOfCake;
        public ChocolateCake() // ctor is not on the interface and is implementation detail
        {
            _isPacked = false;
            _isDecorated = false;
            _nameOfCake = "Шоколадный";
        }       
        public void Interact(IBox box) {...}
        public bool IsPacked { get { return _isPacked; } }
        public bool IsDecorated { get { return _isDecorated; } }
        // ...
    }
    public interface ICakeFactory
    {
        ICake CreateCake();
        IBox CreateBox();
    }
    public class ChocolateCakeFactory : ICakeFactory
    {
        public ICake CreateCake()   {return new ChocolateCake();}
        public IBox CreateBox() {return new ChocolateCakeBox();} 
    }
