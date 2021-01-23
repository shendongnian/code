    public interface IWeapon
    {
        void Fire();
    }
    public class Shotgun : IWeapon
    {
        public void Fire()
        {
            Console.WriteLine("Shotgun goes boom");
        }
    }
    public class Knife : IWeapon
    {
        public void Fire()
        {
            Console.WriteLine("Stabbed teh sucker");
        }
    }
    public class NuclearBomb : IWeapon
    {
        public void Fire()
        {
            Console.WriteLine("Game over for everyone!!1");
        }
    }
