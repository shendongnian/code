    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new WarriorModule());
            var samurai = kernel.Get<ISamurai>();
        }
    }
    public interface ISamurai
    {
    }
    public class Samurai : ISamurai
    {
        public IWeapon Weapon { get; private set; }
        public Samurai(IWeapon weapon)
        {
            this.Weapon = weapon;
        }
    }
    public interface IWeapon
    {
    }
    public class Sword : IWeapon
    {
    }
    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISamurai>().To<Samurai>();
            this.Bind<IWeapon>().To<Sword>();
        }
    }
