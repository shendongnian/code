    private class MyClass
    {
        public MyClass()
        {
            var closure = new <>c__DisplayClass1 { _this = this };
            OkCommand = new ModelCommand(new Action<object>(closure.b__0));
        }
    
        [CompilerGenerated]
        private sealed class <>c__DisplayClass1
        {
            public MyClass _this;
        
            public void b__0(object o)
            {
                return _this.Ok(_this, new EventArgs());
            }
        }
    }
