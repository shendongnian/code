    using Ninject;
    
        enter code here
    
         class ABC
            {
              public void CallingMethodUsingNinject()
                {
                   private IKernel kernel= new StandardKernel();
                   kernel.Load("yourXmlFileName.xml");
                   bool ismodule = kernel.HasModule("myXmlConfigurationModule");//To Check The module 
                   if(ismodule )
                   {           
                   IMyService MyServiceImplementation = kernel.Get<IMyService>();
                   MyServiceImplementation.YourMethod();
                   }
               }
           }
