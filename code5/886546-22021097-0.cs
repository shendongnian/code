    internal class FirstClass : BaseClass
    {
        internal override void GetData()
        {
            // calls GetArticles
        }
    
        protected virtual void GetArticles()
        {
        }
    }
    
    internal class SecondClass : FirstClass
    {
        protected override void GetArticles()
        {
        }
    }
