        public void main()
        {
            List<MethodInvoker> methods = new List<MethodInvoker>();
            methods.Add(new MethodInvoker(SomeMethod));
            foreach (var method in methods)
            {
                method.Invoke();
            }
        }
        public void SomeMethod()
        {
            //... do something
        }
