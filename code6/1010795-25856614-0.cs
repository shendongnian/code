    namespace CompA
    {
        public abstract class Base : IBaseInternal
        {
            protected string ShouldNotBePublic();
            string IBaseInternal.ShouldNotBePublic()
            {
                return ShouldNotBePublic();
            }
        }
        internal interface IBaseInternal
        {
            string ShouldNotBePublic();
        }
    }
