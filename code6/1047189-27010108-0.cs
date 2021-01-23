    abstract class LogicA<T>
        where T: DataA
    {
        public T Data { get; set; }
    
        public virtual void MethodA()
        {
            var data = (DataA)((dynamic)this.Data);
            data.FieldA = "T";
        }
    }
