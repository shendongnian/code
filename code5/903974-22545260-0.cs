    public class ImpersonationContext {
        public delegate bool ImpersonationDel(object obj);
    
        public bool Invoke(ImpersonationDel del){
            using (new Impersonation("LocalHost", "test", "test")){
                return del.Invoke();
            }
        }
    }
