    public abstract class Operand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public dynamic BuildObject()
        {
            dynamic o = new ExpandoObject();
            o.Id = Id;
            o.Name = Name;
            AddPropertiesToObject(o);
            return o;
        }
        protected internal abstract void AddPropertiesToObject(dynamic o);
    }
