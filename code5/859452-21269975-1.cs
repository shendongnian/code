        class Program
    {
        static void Main(string[] args)
        {
            Baldrick baldrick = new Baldrick();
            baldrick.ThingINeedToKnowAboutInSecurityAspect = "Bob";
            Console.WriteLine("There are {0} beans", baldrick.ThingIWantToSecure);
            baldrick.ThingINeedToKnowAboutInSecurityAspect = "Kate";
            try
            {
                //This should fail
                Console.WriteLine("There are {0} beans", baldrick.ThingIWantToSecure);
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
    public class Baldrick : ISecurityProvider
    {
        public string ThingINeedToKnowAboutInSecurityAspect { get; set; }
        [SecurityAspect]
        public int ThingIWantToSecure{get { return 3; }}
    }
    
