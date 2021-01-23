    public interface ICake
    {
        void Interact(IBox box);
        bool IsPacked { get; }
        bool IsDecorated { get; }
        string NameOfCake { get; set; }
   }
    public class ChocolateCake : ICake
    {
        void Interact(IBox box) {}
        bool IsPacked { get { return _isPacked; } }
        bool IsDecorated { get { return _isDecorated; } }
        string NameOfCake { get; set; }
