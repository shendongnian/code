    public class Monitoring 
    {
        public delegate void DoSomethingWithEmail(EmailContents theContents);
    
        public Monitoring(Delegate DoSomethingWithEmail)
        {
            this.DoSomethingWithEmail = DoSomethingWithEmail;
        }
        public void StartMonitoring() {
    
           //When I get an email, I call the method
           DoSomethingWithEmail(theEmailWeJustGot);
        }
    }
