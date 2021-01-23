    public abstract class BaseClass
    {
        //Default properties here
        int x, y, z, ...;
        //Custom made class to hold custom properties
        protected Attributes Properties;
        public abstract BaseClass createNewInstance();
        protected void CopyData(BaseClass original)
        {
            this.x = original.x;
            this.y = original.y;
            this.z = original.z;
        }
    }
    public class ChildClass : BaseClass
    {
        public BaseClass createNewInstance()
        {
            ChildClass newInstance = new ChildClass();
            newInstance.CopyData(this);
       
            // Do any additional copying
            return newInstance;
        }
    }
