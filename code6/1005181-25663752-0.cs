        SampleMethod(this.GetType().GetMethod("WriteHello"), "Hello");
        public void WriteHello(string param)
        {
            Debug.WriteLine(param);
        }
        public void SampleMethod(MethodInfo mi, params object[] arguments)
        {
            mi.Invoke(this,arguments);           
        }
