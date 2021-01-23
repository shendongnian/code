    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.ThingINeedToKnowAboutInSecurityAspect = "Bob";
            Console.WriteLine(testClass.ThingIWantToSecure);
            testClass.ThingINeedToKnowAboutInSecurityAspect = "Kate";
            try
            {
                //This should fail
                Console.WriteLine(testClass.ThingIWantToSecure);
            }
            catch (Exception ex)
            {
                //Expect the message from my invalid operation exception to be written out (Use your own exception if you prefer)
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
    [Serializable]
    public class SecurityAspect : LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            ISecurityProvider securityProvider = args.Instance as ISecurityProvider;
            if (securityProvider != null && securityProvider.ThingINeedToKnowAboutInSecurityAspect != "Bob")
                throw new InvalidOperationException("Access denied (or a better message would be nice!)");
            base.OnGetValue(args);
        }
    }
    
    public interface ISecurityProvider
    {
        string ThingINeedToKnowAboutInSecurityAspect { get; }
    }
    public class TestClass : ISecurityProvider
    {
        public string ThingINeedToKnowAboutInSecurityAspect { get; set; }
        [SecurityAspect]
        public int ThingIWantToSecure{get { return 3; }}
    }
