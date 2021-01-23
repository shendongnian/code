    public abstract class BaseSurvey
    {
        public abstract void DoSomething(param1, param2, param3);
    }
    public abstract class SpecialSurvey : BaseSurvey
    {
        public abstract void DoSomething(param1);
        public void DoSomething(param1, param2, param3)
        {
            DoSomething(param1);
        }
    }
    public class InvitationalSurvey: SpecialSurvey
    {
        public void DoSomething(param1)
        {
             ReallyDoSomething();
        }
    }
