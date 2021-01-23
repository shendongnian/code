    public class Monster : IHealth
    {
        public Monster()
        {
            HealthBar = new MonserHealthBar();
        }
        public IHealthBar HealthBar {get; private set;}
    }
