    public class Registration : IRegistration
    {
        public bool Add(Member m)
        {
            try 
            {
                new MemberRepository().Add(m);
                return true;
            }
            catch(Exception) { return false; }
        }
        
        // Other IRegistration implementations
    }
