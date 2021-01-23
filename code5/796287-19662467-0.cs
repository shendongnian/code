    public abstract class MyModel
    {
        public void Patch(Object u)
        {
            var props = from p in this.GetType().GetProperties()
                        let attr = p.GetCustomAttribute(typeof(NotPatchableAttribute))
                        where attr == null
                        select p;
            foreach (var prop in props)
            {
                var val = prop.GetValue(this, null);
                if (val != null)
                    prop.SetValue(u, val);
            }
        }
    }
