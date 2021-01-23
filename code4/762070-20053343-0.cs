    try
            {
                MbnInterfaceManager mbnInfMgr = new MbnInterfaceManager(); 
                IMbnInterfaceManager mbnInfMgrInterface = mbnInfMgr as IMbnInterfaceManager;
                if (mbnInfMgrInterface != null)
                {
                    IMbnInterface[] mobileInterfaces = mbnInfMgrInterface.GetInterfaces() as IMbnInterface[];
                    if (mobileInterfaces != null && mobileInterfaces.Length > 0)
                    {
                        // Just use the first interface
                        IMbnSubscriberInformation subInfo = mobileInterfaces[0].GetSubscriberInformation();
                        if (subInfo != null)
                        {
                            SIMNumber = subInfo.SimIccID;
                            // Get the connection profile
                            MbnConnectionProfileManager mbnConnProfileMgr = new MbnConnectionProfileManager();
                            IMbnConnectionProfileManager mbnConnProfileMgrInterface = mbnConnProfileMgr as IMbnConnectionProfileManager; 
                            if (mbnConnProfileMgrInterface != null)
                            {
                                bool connProfileFound = false;
                                string profileName = String.Empty;
                                try
                                {
                                    IMbnConnectionProfile[] mbnConnProfileInterfaces = mbnConnProfileMgrInterface.GetConnectionProfiles(mobileInterfaces[0]) as IMbnConnectionProfile[];
                                    foreach (IMbnConnectionProfile profile in mbnConnProfileInterfaces)
                                    {
                                        string xmlData = profile.GetProfileXmlData();
                                        if (xmlData.Contains("<SimIccID>" + SIMNumber + "</SimIccID>"))
                                        {
                                            connProfileFound = true;
                                            bool updateRequired = false;
                                            
                                            // Check if the profile is set to auto connect
                                            XmlDocument xdoc = new XmlDocument();
                                            xdoc.LoadXml(xmlData);
                                            profileName = xdoc["MBNProfile"]["Name"].InnerText;
                                            if (xdoc["MBNProfile"]["ConnectionMode"].InnerText != "auto")
                                            {
                                                xdoc["MBNProfile"]["ConnectionMode"].InnerText = "auto";
                                                updateRequired = true;
                                            }
                                            // Check the APN settings
                                            if (xdoc["MBNProfile"]["Context"] == null)
                                            {
                                                XmlElement context = (XmlElement)xdoc["MBNProfile"].AppendChild(xdoc.CreateElement("Context", xdoc["MBNProfile"].NamespaceURI));
                                                context.AppendChild(xdoc.CreateElement("AccessString", xdoc["MBNProfile"].NamespaceURI));
                                                context.AppendChild(xdoc.CreateElement("Compression", xdoc["MBNProfile"].NamespaceURI));
                                                context.AppendChild(xdoc.CreateElement("AuthProtocol", xdoc["MBNProfile"].NamespaceURI));
                                                updateRequired = true;
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["AccessString"].InnerText != APNAccessString)
                                            {
                                                xdoc["MBNProfile"]["Context"]["AccessString"].InnerText = APNAccessString;
                                                updateRequired = true;
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["Compression"].InnerText != APNCompression)
                                            {
                                                xdoc["MBNProfile"]["Context"]["Compression"].InnerText = APNCompression;
                                                updateRequired = true;
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["AuthProtocol"].InnerText != APNAuthProtocol)
                                            {
                                                xdoc["MBNProfile"]["Context"]["AuthProtocol"].InnerText = APNAuthProtocol;
                                                updateRequired = true;
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["UserLogonCred"] == null && !String.IsNullOrEmpty(APNUsername))
                                            {
                                                XmlElement userLogonCred = (XmlElement)xdoc["MBNProfile"]["Context"].InsertAfter(xdoc.CreateElement("UserLogonCred", xdoc["MBNProfile"].NamespaceURI), xdoc["MBNProfile"]["Context"]["AccessString"]);
                                                userLogonCred.AppendChild(xdoc.CreateElement("UserName", xdoc["MBNProfile"].NamespaceURI));
                                                userLogonCred.AppendChild(xdoc.CreateElement("Password", xdoc["MBNProfile"].NamespaceURI));
                                                updateRequired = true;
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["UserLogonCred"] != null && xdoc["MBNProfile"]["Context"]["UserLogonCred"]["UserName"].InnerText != APNUsername)
                                            {
                                                xdoc["MBNProfile"]["Context"]["UserLogonCred"]["UserName"].InnerText = APNUsername;
                                                updateRequired = true;
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["UserLogonCred"] != null && xdoc["MBNProfile"]["Context"]["UserLogonCred"]["Password"] == null && !String.IsNullOrEmpty(APNUsername))
                                            {
                                                xdoc["MBNProfile"]["Context"]["UserLogonCred"].AppendChild(xdoc.CreateElement("Password", xdoc["MBNProfile"].NamespaceURI));
                                            }
                                            if (xdoc["MBNProfile"]["Context"]["UserLogonCred"] != null && xdoc["MBNProfile"]["Context"]["UserLogonCred"]["Password"].InnerText != APNPassword)
                                            {
                                                xdoc["MBNProfile"]["Context"]["UserLogonCred"]["Password"].InnerText = APNPassword;
                                                updateRequired = true;
                                            }
                                            if (updateRequired)
                                            {
                                                // Update the connection profile
                                                profile.UpdateProfile(xdoc.OuterXml);
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (!ex.Message.Contains("Element not found"))
                                    {
                                        throw ex;
                                    }
                                }
                                if (!connProfileFound)
                                {
                                    // Create the connection profile
                                    XmlDocument xdoc = new XmlDocument();
                                    xdoc.AppendChild(xdoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));
                                    XmlElement mbnProfile = (XmlElement)xdoc.AppendChild(xdoc.CreateElement("MBNProfile", "http://www.microsoft.com/networking/WWAN/profile/v1"));
                                    mbnProfile.AppendChild(xdoc.CreateElement("Name", xdoc["MBNProfile"].NamespaceURI)).InnerText = SIMNumber;
                                    mbnProfile.AppendChild(xdoc.CreateElement("IsDefault", xdoc["MBNProfile"].NamespaceURI)).InnerText = "true";
                                    mbnProfile.AppendChild(xdoc.CreateElement("ProfileCreationType", xdoc["MBNProfile"].NamespaceURI)).InnerText = "DeviceProvisioned";
                                    mbnProfile.AppendChild(xdoc.CreateElement("SubscriberID", xdoc["MBNProfile"].NamespaceURI)).InnerText = subInfo.SubscriberID;
                                    mbnProfile.AppendChild(xdoc.CreateElement("SimIccID", xdoc["MBNProfile"].NamespaceURI)).InnerText = SIMNumber;
                                    mbnProfile.AppendChild(xdoc.CreateElement("HomeProviderName", xdoc["MBNProfile"].NamespaceURI)).InnerText = SIMNumber;
                                    mbnProfile.AppendChild(xdoc.CreateElement("AutoConnectOnInternet", xdoc["MBNProfile"].NamespaceURI)).InnerText = "true";
                                    mbnProfile.AppendChild(xdoc.CreateElement("ConnectionMode", xdoc["MBNProfile"].NamespaceURI)).InnerText = "auto";
                                    
                                    XmlElement context = (XmlElement)xdoc["MBNProfile"].AppendChild(xdoc.CreateElement("Context", xdoc["MBNProfile"].NamespaceURI));
                                    context.AppendChild(xdoc.CreateElement("AccessString", xdoc["MBNProfile"].NamespaceURI));
                                    XmlElement userLogonCred = (XmlElement)context.AppendChild(xdoc.CreateElement("UserLogonCred", xdoc["MBNProfile"].NamespaceURI));
                                    userLogonCred.AppendChild(xdoc.CreateElement("UserName", xdoc["MBNProfile"].NamespaceURI));
                                    userLogonCred.AppendChild(xdoc.CreateElement("Password", xdoc["MBNProfile"].NamespaceURI));
                                    context.AppendChild(xdoc.CreateElement("Compression", xdoc["MBNProfile"].NamespaceURI));
                                    context.AppendChild(xdoc.CreateElement("AuthProtocol", xdoc["MBNProfile"].NamespaceURI));
                                    xdoc["MBNProfile"]["Context"]["AccessString"].InnerText = APNAccessString;
                                    xdoc["MBNProfile"]["Context"]["UserLogonCred"]["UserName"].InnerText = APNUsername;
                                    xdoc["MBNProfile"]["Context"]["UserLogonCred"]["Password"].InnerText = APNPassword;
                                    xdoc["MBNProfile"]["Context"]["Compression"].InnerText = APNCompression;
                                    xdoc["MBNProfile"]["Context"]["AuthProtocol"].InnerText = APNAuthProtocol;
                                    profileName = xdoc["MBNProfile"]["Name"].InnerText;
                                    mbnConnProfileMgrInterface.CreateConnectionProfile(xdoc.OuterXml); 
                                }
                                // Register the connection events
                                MbnConnectionManager connMgr = new MbnConnectionManager();
                                IConnectionPointContainer connPointContainer = connMgr as IConnectionPointContainer;
                                Guid IID_IMbnConnectionEvents = typeof(IMbnConnectionEvents).GUID;
                                IConnectionPoint connPoint;
                                connPointContainer.FindConnectionPoint(ref IID_IMbnConnectionEvents, out connPoint);
                                ConnectionEventsSink connEventsSink = new ConnectionEventsSink();
                                connPoint.Advise(connEventsSink, out cookie); if (showProgress) { MessageBox.Show("After registering events"); }
                                // Connect
                                IMbnConnection connection = mobileInterfaces[0].GetConnection();
                                if (connection != null)
                                {
                                    MBN_ACTIVATION_STATE state;
                                    string connectionProfileName = String.Empty;
                                    connection.GetConnectionState(out state, out connectionProfileName);
                                    if (state != MBN_ACTIVATION_STATE.MBN_ACTIVATION_STATE_ACTIVATED && state != MBN_ACTIVATION_STATE.MBN_ACTIVATION_STATE_ACTIVATING)
                                    {
                                        if (String.IsNullOrEmpty(connectionProfileName))
                                        {
                                            connectionProfileName = profileName;
                                        }
                                        uint requestID;
                                        connection.Connect(MBN_CONNECTION_MODE.MBN_CONNECTION_MODE_PROFILE, connectionProfileName, out requestID);
                                    }
                                    else
                                    {
                                        // Do nothing, already connected
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Connection not found.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("mbnConnProfileMgrInterface is null.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No subscriber info found.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No mobile interfaces found.");
                    }
                }
                else
                {
                    MessageBox.Show("mbnInfMgrInterface is null.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("SIM is not inserted."))
                {
                    SIMNumber = "No SIM inserted.";
                }
                MessageBox.Show("LoginForm.DataConnection ConfigureWindowsDataConnection Error " + ex.Message);
            }
