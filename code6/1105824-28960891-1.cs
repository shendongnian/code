    public class MyClass
    {
        private long value2;
        public int Value1 { get; set; }
        public long Value2
        {
            get
            {
                if (value2 == 0)
                {
                    // value2 is a long. If the .NET is running at 32 bits,
                    // the assignment of a long (64 bits) isn't atomic :)
                    value2 = LoadFromServer();
                    // If thread1 checks and see value2 == 0 and loads it,
                    // and then begin writing value2 = (value), but after
                    // writing the first 32 bits of value2 we have that
                    // thread2 reads value2, then thread2 will read an
                    // "incomplete" data. If this "incomplete" data is == 0
                    // then a second LoadFromServer() will be done. If the
                    // operation was repeatable then there won't be any 
                    // problem (other than time wasted). But if the 
                    // operation isn't repeatable, or if the incomplete 
                    // data that is read is != 0, then there will be a
                    // problem (for example an exception if the operation 
                    // wasn't repeatable, or different data if the operation
                    // wasn't deterministic, or incomplete data if the read
                    // was != 0)
                }
                return value2;
            }
        }
        private long LoadFromServer()
        {
            // This is a slow operation that justifies a lazy property
            return 1; 
        }
        public override int GetHashCode()
        {
            // The GetHashCode doesn't use Value2, because it
            // wants to be fast
            return Value1;
        }
        public override bool Equals(object obj)
        {
            MyClass obj2 = obj as MyClass;
            if (obj2 == null)
            {
                return false;
            }
            // The equality operator uses Value2, because it
            // wants to be correct.
            // Note that probably the HashSet<T> doesn't need to
            // use the Equals method on Add, if there are no
            // other objects with the same GetHashCode
            // (and surely, if the HashSet is empty and you Add a
            // single object, that object won't be compared with
            // anything, because there isn't anything to compare
            // it with! :-) )
            // Clearly the Equals is used by the Contains method
            // of the HashSet
            return Value1 == obj2.Value1 && Value2 == obj2.Value2;
        }
    }
