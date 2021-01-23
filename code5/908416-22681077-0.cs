    public abstract class BaseSurvey
    {
        public abstract void DoSomething(param1);
    }
    
    public class InvitationalSurvey: BaseSurvey
    {
        public void DoSomething(param1)
        {
        }
    }
    
    
    public class ReturnLaterSurvey: BaseSurvey
    {
        public abstract void DoSomething(param1)
        {
        }
    }
    
    
    public class AnonymousSurvey: BaseSurvey
    {
        private readonly object param2;
        private readonly object param3
    
        public AnonymousSurvey(param2, param3)
        {
            this.param2 = param2;
            this.param3 = param3;
        }
    
        public abstract void DoSomething(param1)
        {
            // use this.param2 and this.param3 here
        }
    }
