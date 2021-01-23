        using System.Configuration;
        using System.IO;
        using TechTalk.SpecFlow;
        namespace Foo
        {
            [Binding]
            public class CommonHooks
            {
                [BeforeScenario]
                public void BeforeScenario()
                {
                    InitFixturesPath();
                }
                private void InitFixturesPath()
                {
                    if (ScenarioContext.Current.ContainsKey("FixturesPath"))
                        return;
                    string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                                    + Path.DirectorySeparatorChar
                                    + ConfigurationManager.AppSettings["FixturesRootDirectory"];
                    UriBuilder uri = new UriBuilder(codeBase);
                    string path = Uri.UnescapeDataString(uri.Path);
                    ScenarioContext.Current.Set<string>("FixturesPath", Path.GetDirectoryName(path));
                }
            }
        }
