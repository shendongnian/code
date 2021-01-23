    public class Sprite
    {
        private double _x = 0, _y = 0;
        public void Run()
        {
            var random = new byte[2];
            new Random().NextBytes(random);
            _x += (double)random[0];
            _y += (double)random[1];
        }
        public void Render()
        {
            Console.WriteLine("({0}, {1})", _x, _y);
        }
    }
