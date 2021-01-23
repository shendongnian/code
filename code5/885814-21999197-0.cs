    class EnemyBaseScript
    {
        protected virtual void Start()
        {
            //...
        }
    }
    class L1EnemyBaseScript : EnemyBaseScript
    {
        protected override void Start()
        {
            base.Start();
            //...
        }
    }
