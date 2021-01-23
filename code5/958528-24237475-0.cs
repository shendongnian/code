    class abstract B
    {
    
        public int login()
        {
            parseSite();
        }
    
        protected abstract void parseSite();
    
    }
    
    class C : B
    {
    
        protected override void parseSite()
        {
    
        }
    
    }
    
    class D : B
    {
    
        protected override void parseSite()
        {
    
        }
    
    }
