        public class Job
        {
    
            private void Test()
            {
    
            }
    
            public class JobChild : Job
            {
                public JobChild()
                {
                    //works
                    this.Test();
                }
    
            }
        }
    
    
        public class JobChildTwo : Job.JobChild
        {
            public JobChildTwo()
            {
                //doesn't work
                this.Test();
            }
        }
    
    
   
