        public void Method1()
        {
            //var nested = new Private2.Nested(); //old code
            var nested = new Private3.Nested(); //new code
            nested.Test(this);
        }
