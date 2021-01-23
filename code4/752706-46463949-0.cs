    09:45:31.894 |W| UnitTestLaunch                | System.ApplicationException: Error loading settings file
    System.ApplicationException: Error loading settings file ---> System.Xml.XmlException: Root element is missing.
       at System.Xml.XmlTextReaderImpl.Throw(Exception e)
       at System.Xml.XmlTextReaderImpl.ParseDocumentContent()
       at System.Xml.XmlLoader.Load(XmlDocument doc, XmlReader reader, Boolean preserveWhitespace)
       at System.Xml.XmlDocument.Load(XmlReader reader)
       at System.Xml.XmlDocument.Load(String filename)
       at NUnit.Engine.Internal.SettingsStore.LoadSettings()
       --- End of inner exception stack trace ---
       at NUnit.Engine.Internal.SettingsStore.LoadSettings()
       at NUnit.Engine.Services.SettingsService.StartService()
       at NUnit.Engine.Services.ServiceManager.StartServices()
       at NUnit.Engine.TestEngine.Initialize()
       at NUnit.Engine.TestEngine.GetRunner(TestPackage package)
       at JetBrains.ReSharper.UnitTestRunner.nUnit30.BuiltInNUnitRunner.<>c__DisplayClass1.<RunTests>b__0()
       at JetBrains.ReSharper.UnitTestRunner.nUnit30.BuiltInNUnitRunner.WithExtensiveErrorHandling(IRemoteTaskServer server, Action action)
