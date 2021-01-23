    using System;
    using Microsoft.VisualStudio.TestTools.LoadTesting;
    using System.IO;
    using System.Xml;
    
    namespace LoadTest
    {
        public class LoadTestPluginImpl : ILoadTestPlugin
        {
    
            LoadTest mLoadTest;
    
            static int TotalIterations;
            public void Initialize(LoadTest loadTest)
            {
                mLoadTest = loadTest;
                //connect to the TestStarting event.
                mLoadTest.TestStarting += new EventHandler<TestStartingEventArgs>(mLoadTest_TestStarting);
                ReadTestConfig();
            }
    
            void mLoadTest_TestStarting(object sender, TestStartingEventArgs e)
            {
                //When the test starts, copy the load test context parameters to
                //the test context parameters
                foreach (string key in mLoadTest.Context.Keys)
                {
                    e.TestContextProperties.Add(key, mLoadTest.Context[key]);
                }
                //add the CurrentTestIteration to the TestContext
                e.TestContextProperties.Add("TestIterationNumber", e.TestIterationNumber);
                //add the TotalIterations to the TestContext and access from the Unit Test.
                e.TestContextProperties.Add("TotalIterations", TotalIterations);
                
            }
    
            void ReadTestConfig()
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, mLoadTest.Name + ".loadtest");
    
                if (File.Exists(filePath))
                {
                    string runSettings = mLoadTest.RunSettings.Name;
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(filePath);
    
                    XmlElement root = xdoc.DocumentElement;
    
                    string xmlNameSpace = root.GetAttribute("xmlns");
                    XmlNamespaceManager xmlMgr = new XmlNamespaceManager(xdoc.NameTable);
                    if (!string.IsNullOrWhiteSpace(xmlNameSpace))
                    {
                        xmlMgr.AddNamespace("lt", xmlNameSpace);
                    }
    
                    var nodeRunSettings = xdoc.SelectSingleNode(string.Format("//lt:LoadTest/lt:RunConfigurations/lt:RunConfiguration[@Name='{0}']", runSettings), xmlMgr);
                    //var nodeRunSettings = xdoc.SelectSingleNode(string.Format("//lt:LoadTest", runSettings), xmlMgr);
                    if (nodeRunSettings != null)
                    {
                        TotalIterations = Convert.ToInt32(nodeRunSettings.Attributes["TestIterations"].Value);
                    }
    
                }
            }
        }
    }
