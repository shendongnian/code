    public interface IHaveInterface
    {
        void Hallo();
    }
    internal partial class Settings : IHaveInterface
    {
        public void Hallo()
        {
            Console.WriteLine("Hallo");
        }
    }
