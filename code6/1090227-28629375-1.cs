    [DurationCalculatorInterceptor(false)]
    public class WithoutExceptionHandling : ContextBoundObject
    {
        public void DivideYeahWithoutExceptionHandling()
        {
            for (int i = 0; i < 1000000; i++)
            {
                try
                {
                    var x = 2;
                    var y = 1;
                    var z = x / (y - 1);
                }
                catch (Exception)
                {
                }
            }
        }
    }
    [DurationCalculatorInterceptor(true)]
    public class WithExceptionHandling : ContextBoundObject
    {
        public void DivideYeahWithExceptionHandling()
        {
            for (int i = 0; i < 1000000; i++)
            {
                var x = 2;
                var y = 1;
                var z = x / (y - 1);
            }
        }
    }
