       public GovTalkMessage CreateRequestMessage(string env)
            {
                try
                {
                    log.Debug("CreateRequestMessage called");
                    GovTalkMessageBody Body = new GovTalkMessageBody();
                                    
                    IR68 ir68 = new IR68(_localData);
                    log.Debug("Creating IR68 body ...");
    
                    IRenvelope ire = new IRenvelope();
                    ire = ir68.CreateIRBody();
    
                    //serialize ire into XmlElement and then set Body.Any = 
    
                    XmlElement xe = GiftAidSubmissionProcessController.SerializeIREnvelope(ire);
                    XmlElement[] XmlElementIRenvelope = new XmlElement[1];
                    XmlElementIRenvelope[0] = xe;
                    
                    Body.Any = XmlElementIRenvelope;
    
                    //GovTalkDetails
    
                    GovTalkMessageGovTalkDetailsChannelRoutingChannel Channel = new GovTalkMessageGovTalkDetailsChannelRoutingChannel();
                    Channel.Version = ConfigurationManager.AppSettings["ChannelVersion"];
                    Channel.Product = ConfigurationManager.AppSettings["ChannelProduct"];
                    Channel.ItemElementName = ItemChoiceType.URI;
                    Channel.Item = ConfigurationManager.AppSettings["ChannelURI"];
    
                    GovTalkMessageGovTalkDetailsChannelRouting ChannelRouting = new GovTalkMessageGovTalkDetailsChannelRouting();
                    ChannelRouting.Channel = Channel;
    
                    GovTalkMessageGovTalkDetailsKey Key = new GovTalkMessageGovTalkDetailsKey();
                    Key.Type = ConfigurationManager.AppSettings["GovTalkDetailsKeyType"];
                    Key.Value = ConfigurationManager.AppSettings["GovTalkDetailsKey"];
    
                    GovTalkMessageGovTalkDetails Details = new GovTalkMessageGovTalkDetails();
    
                    GovTalkMessageGovTalkDetailsChannelRouting[] ChannelRoutings = 
                        new GovTalkMessageGovTalkDetailsChannelRouting[1];
                    ChannelRoutings[0] = ChannelRouting;
                    Details.ChannelRouting = ChannelRoutings;
    
                    GovTalkMessageGovTalkDetailsKey[] Keys = new GovTalkMessageGovTalkDetailsKey[1];
                    Keys[0] = Key;
                    Details.Keys = Keys;
    
                    string[] TargetDetails = new string[1];
                    TargetDetails[0] = ConfigurationManager.AppSettings["GovTalkDetailsTargetOrganistion"];
                    Details.TargetDetails = TargetDetails;
    
                    //GovTalk Header
    
                    GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthentication Authentication = new GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthentication();
                    switch (ConfigurationManager.AppSettings["SenderAuthenticationMethod"])
                    {
                        case "MD5":
                            Authentication.Method = GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthenticationMethod.MD5;
                            break;
                        case "clear":
                            Authentication.Method = GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthenticationMethod.clear;
                            break;
                        case "W3Csigned":
                            Authentication.Method = GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthenticationMethod.W3Csigned;
                            break;
                    }
                    Authentication.Role = ConfigurationManager.AppSettings["SenderAuthenticationRole"];
                    Authentication.Item = ConfigurationManager.AppSettings["SenderAuthenticationValue"];
    
                    GovTalkMessageHeaderSenderDetailsIDAuthentication IDAuthentication = new GovTalkMessageHeaderSenderDetailsIDAuthentication();
                    IDAuthentication.SenderID = ConfigurationManager.AppSettings["SenderID"];
    
                    GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthentication[] Authentications = new GovTalkMessageHeaderSenderDetailsIDAuthenticationAuthentication[1];
                    Authentications[0] = Authentication;
                    IDAuthentication.Authentication = Authentications;
    
                    GovTalkMessageHeaderSenderDetails SenderDetails = new GovTalkMessageHeaderSenderDetails();
                    SenderDetails.IDAuthentication = IDAuthentication;
    
                    GovTalkMessageHeaderMessageDetails MessageDetails = new GovTalkMessageHeaderMessageDetails();
                    MessageDetails.Class = ConfigurationManager.AppSettings["MessageDetailsClass"];
                    MessageDetails.Qualifier = GovTalkMessageHeaderMessageDetailsQualifier.request;
                    MessageDetails.FunctionSpecified = true;
                    MessageDetails.Function = GovTalkMessageHeaderMessageDetailsFunction.submit;
                    MessageDetails.TransformationSpecified = true;
                    MessageDetails.Transformation = GovTalkMessageHeaderMessageDetailsTransformation.XML;
                    MessageDetails.GatewayTest = ConfigurationManager.AppSettings["MessageDetailsGatewayTest"];
                    if (env == "local")
                    {
                        MessageDetails.GatewayTimestampSpecified = true;
                        MessageDetails.GatewayTimestamp = DateTime.Now;
                    }
                    else
                    {
                        MessageDetails.GatewayTimestampSpecified = false;
                        MessageDetails.GatewayTimestamp = DateTime.MinValue; }
    
                    GovTalkMessageHeader Header = new GovTalkMessageHeader();
                    Header.MessageDetails = MessageDetails;
                    Header.SenderDetails = SenderDetails;
    
                    GovTalkMessage GovTalkMessage = new hmrcclasses.GovTalkMessage();
    
                    GovTalkMessage.EnvelopeVersion = ConfigurationManager.AppSettings["GovTalkMessageEnvelopeVersion"];
                    GovTalkMessage.Header = Header;
                    GovTalkMessage.GovTalkDetails = Details;
                    GovTalkMessage.Body = Body;
    
                    log.Info("GovTalkMessage created successfully");
    
                    return GovTalkMessage;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw;
                }
    
            }
