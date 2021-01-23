    public class HidingVehicle : HonkClass
    {
        public void Honk()
        {
            Console.Writeline("Hiding honk!");
        }
    }
    public class OverridingVehicle : HonkClass
    {
        public override void Honk()
        {
            Console.Writeline("Overriding honk!");
        }
    }
    public class HonkClass
    {
        public virtual void Honk()
        {
            Console.Writeline("Base honk!");
        }
    }
