    namespace My.Special.Assembly.With
    {
        public class MyType
        {
            public MyType()
            {
                var log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }
    }
