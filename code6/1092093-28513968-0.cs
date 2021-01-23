    public class UnityTool<IClass,cbClass>
              where IClass:class
    	      where cbClass:class
    {
        public static void UnityTest()
        {
            IUnityContainer container = new UnityContainer();
    
            container.RegisterType<IClass, cbClass>();        
        }
    }
