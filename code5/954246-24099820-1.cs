    public class ObjectResolver
    {
        private readonly Assembly _myDal;
        public ObjectResolver()
        {
           _myDal = Assembly.Load("DAL");
            
        }
        public object Resolve(string nameSpace,  string name)
        {
            var myLoadClass = _myDal.GetType(nameSpace + "." + name); 
            return Activator.CreateInstance(myLoadClass);
        }
    }
