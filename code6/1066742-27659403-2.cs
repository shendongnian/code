    class PrepareTimer : TimerAction
    {
        public override void OnStart()
        {
            Console.WriteLine("Preparing");
            Started = true;
        }
        public override void OnComplete()
        {
            Console.WriteLine("Prepare ready");
            Completed = true;
        }
    }
    class WorkTimer : TimerAction
    {
        public override void OnStart()
        {
            Console.WriteLine("Working");
            Started = true;
        }
        public override void OnComplete()
        {
            Console.WriteLine("Work ready");
            Completed = true;
        }
    }
    class CoolDownTimer : TimerAction
    {
        public override void OnStart()
        {
            Console.WriteLine("Cooling down");
            Started = true;
        }
        public override void OnComplete()
        {
            Console.WriteLine("Cooldown ready");
            Completed = true;
        }
    }
