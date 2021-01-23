    public AbstractFactory{
        public AbstractFactory (IConfiguration config){
            this.presentationClassNameSpace = config.PresentationClassNameSpace;
        }
        private readonly string presentationClassNameSpace;
        public AbstractPresentationClass Resolve(Type t){
            string className = t.Name;
            className = className.Replace("Domain", "Presentation");
            AbstractPresentationClass resultClass = 
                (AbstractPresentationClass) System.Activator.CreateInstance(
                    Type.GetType(presentationClassNameSpace + "." + className);
            return resultClass;
        }
    }
