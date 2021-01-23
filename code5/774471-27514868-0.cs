    [TestFixtureTearDown]
    protected void TeardownLogging()
    {
        if (m_appender != null)
        {
            m_appender.Clear();
            m_appender.Close();
        }
        m_appender = null;
    
        var appenders = ((log4net.Repository.Hierarchy.Hierarchy) LogManager.GetRepository()).Root as log4net.Core.IAppenderAttachable;
        appenders.RemoveAllAppenders();
    }
