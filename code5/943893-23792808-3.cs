    [TestClass]
    public class WebConfigTest
    {
        /// <summary>
        /// in Web.config, debug mode must be set to 'false'
        /// </summary>
        [TestMethod]
        public void TestDebugFalse()
        {
            var path                    = @"Path to web.config";
            var webConfig               = new System.IO.FileInfo(path);
            var virtualDirectoryMapping = new System.Web.Configuration.VirtualDirectoryMapping(webConfig.DirectoryName, true, webConfig.Name);
            var fileMap                 = new System.Web.Configuration.WebConfigurationFileMap();
            fileMap.VirtualDirectories.Add("/", virtualDirectoryMapping);
            var configuration           = System.Web.Configuration.WebConfigurationManager.OpenMappedWebConfiguration(fileMap, "/");
            var compilation             = configuration.GetSection("system.web/compilation");
            if(compilation != null)
            {
                var debug = ((System.Web.Configuration.CompilationSection)compilation).Debug;
                Assert.AreEqual("false", debug);
            }
        }
    }
