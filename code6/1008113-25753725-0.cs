    private class myClasses
    {
        private class subOne
        {
            public virtual string SOfieldOne
            {
                get { return "blahblah"; }
            }
        }
        private class subTwo : subOne
        {
            public override string SOfieldOne
            {
                get { return "something else"; }
            }
        }
    }
