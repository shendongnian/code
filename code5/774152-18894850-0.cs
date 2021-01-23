    interface IProgressToken
    {
        void SetProgress(float percentage);
    }
    class MyProgressToken : IProgressToken
    {
        void SetProgress(float percentage)
        {
            Console.WriteLine("current progress: " + percentage + "%");
        }
    }
    // The long running method
    ResultType MyCalculationMethod(InputType input, IProgressToken progressToken)
    {
        progressToken.SetProgress(0);
        ...
        progressToken.SetProgress(100);
    }
