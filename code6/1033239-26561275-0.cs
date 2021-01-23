    internal static EasyTrackerConfig Load(XmlReader reader)
    {
        // advance to first element
        while (reader.NodeType != XmlNodeType.Element && !reader.EOF)
        {
            reader.Read();
        }
        if (!reader.EOF && reader.Name == "analytics")
        {
            return LoadConfigXml(reader);
        }
        return new EasyTrackerConfig();
    }
    private static EasyTrackerConfig LoadConfigXml(XmlReader reader)
    {
        var result = new EasyTrackerConfig();
        reader.ReadStartElement("analytics");
        do
        {
            if (reader.IsStartElement())
            {
                switch (reader.Name)
                {
                    case "trackingId":
                        result.TrackingId = reader.ReadElementContentAsString();
                        break;
                    case "appName":
                        result.AppName = reader.ReadElementContentAsString();
                        break;
                    case "appVersion":
                        result.AppVersion = reader.ReadElementContentAsString();
                        break;
                    case "appId":
                        result.AppId = reader.ReadElementContentAsString();
                        break;
                    case "appInstallerId":
                        result.AppInstallerId = reader.ReadElementContentAsString();
                        break;
                    case "sampleFrequency":
                        result.SampleFrequency = reader.ReadElementContentAsFloat();
                        break;
                    case "dispatchPeriod":
                        var dispatchPeriodInSeconds = reader.ReadElementContentAsInt();
                        result.DispatchPeriod = TimeSpan.FromSeconds(dispatchPeriodInSeconds);
                        break;
                    case "sessionTimeout":
                        var sessionTimeoutInSeconds = reader.ReadElementContentAsInt();
                        result.SessionTimeout = (sessionTimeoutInSeconds >= 0) ? TimeSpan.FromSeconds(sessionTimeoutInSeconds) : (TimeSpan?)null;
                        break;
                    case "debug":
                        result.Debug = reader.ReadElementContentAsBoolean();
                        break;
                    case "autoAppLifetimeTracking":
                        result.AutoAppLifetimeTracking = reader.ReadElementContentAsBoolean();
                        break;
                    case "autoAppLifetimeMonitoring":
                        result.AutoAppLifetimeMonitoring = reader.ReadElementContentAsBoolean();
                        break;
                    case "anonymizeIp":
                        result.AnonymizeIp = reader.ReadElementContentAsBoolean();
                        break;
                    case "reportUncaughtExceptions":
                        result.ReportUncaughtExceptions = reader.ReadElementContentAsBoolean();
                        break;
                    case "useSecure":
                        result.UseSecure = reader.ReadElementContentAsBoolean();
                        break;
                    case "autoTrackNetworkConnectivity":
                        result.AutoTrackNetworkConnectivity = reader.ReadElementContentAsBoolean();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
            else
            {
                reader.ReadEndElement();
                break;
            }
        }
        while (true);
        return result;
    }
