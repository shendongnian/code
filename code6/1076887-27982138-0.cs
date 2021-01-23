    private object threadUnsafeObject;
        private object locker = new object();
        private void RunMulitpleThread()
        {
            object pass_your_parameter_here = "";
            for (int iCount = 0; iCount < 5; iCount++)
            {
                System.Threading.Thread thread = new System.Threading.Thread(DoWork);
                thread.Start(pass_your_parameter_here);
                
            }
        }
        
        private void DoWork(object parameters)
        {
            lock (locker)
            {
                threadUnsafeObject = parameters;
            }
        }
