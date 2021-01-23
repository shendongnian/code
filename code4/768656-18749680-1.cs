    public class FirstLink : Link
    {
        public override decimal Execute(int time)
        {
            if (time > 0 && time <= 499)
            {
                return .75m;
            }
            return base.Execute(time);
        }
    }
    public class SecondLink : Link
    {
        public override decimal Execute(int time)
        {
            if (time > 500 && time <= 999)
            {
                return .85m;
            }
            return base.Execute(time);
        }
    }
    public class ThirdLink : Link
    {
        public override decimal Execute(int time)
        {
            if (time >= 1000)
            {
                return 1.00m;
            }
            return base.Execute(time);
        }
    }
