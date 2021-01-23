    [Serializable]
    class ExceptionWrapper : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            LogError(args.Exception);
            //throw args.Exception;
        }
    }
    [ExceptionWrapper]
    class SampleRepositoryClass
    {
        public void MethodA()
        {
            //Do Something
        }
        void MethodB(int a, int b)
        {
            //Do Something
        }
        List<int> MethodC(int userId)
        {
            //Do Something
        }
    }
