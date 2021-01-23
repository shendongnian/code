    interface IMyConditionEvaluator 
    {
        bool EvaluateCondition(int x, int y); 
    }
    …
    IMyConditionEvaluator e = new SomeSpecificConditionEvaluator();
    …
    if (e.EvaluateCondition(seconds, choosedSeconds))
    {
        …
    }
