    public class Class1 : MarshalByRefObject, ICanDoSomething
    {
        public string TellMeYourVersionsAndDependencyVersions()
        {
            return
                typeof(Class1).Assembly.GetName().Version + "\n\n" +
                "My reference to Domain\n=================\n " + SomeModel.TellMeYourVersionsAndDependencyVersions() + "\n\n" +
                "My reference to Common\n=================\n " + SomeUtility.TellMeYourVersion();
        }
    }
