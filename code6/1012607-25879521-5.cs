    public class Service {
        public void Fn<T>(Type t) {
            I i = Activator.CreateInstance(t) as I;
            if(i != null)
                i.M();
            // ...
        }
    }
