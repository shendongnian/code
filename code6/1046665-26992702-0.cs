    class Base
    {
        protected virtual bool Delete(Guid? id)
        {
            bool result = false;
            if (id != null)
            {
                // ...
                result = true;
            }
            return result;
        }
    }
    internal class Derived : Base
    {
        protected override bool Delete(Guid? id)
        {
            if (!base.Delete(id))
                return false;
            // ...
            return true;
        }
    }
