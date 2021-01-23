    static class BLFactory<U> where U:BaseElement
    {
        public static IOperation<U> CreateObject()
        {
            if (typeof(U).Name == "SubjectDTO")
            {
                return new Student() as IOperation<U>;
            }
            else
            {
                return new Subject() as IOperation<U>;
            }
        }        
    }
