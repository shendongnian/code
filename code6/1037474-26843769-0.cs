    case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                   
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    break;
                case SoapMessageStage.AfterDeserialize:
                    foreach (SoapHeader header in message.Headers)
                    {
                        if (header.GetType() == typeof(RouteInformation))
                        {
                            routeHdr = (RouteInformation) header;
                            if(!string.IsNullOrEmpty(routeHdr.ConsumerID))
                                id = DataFix.FixInt(routeHdr.ID);
                        }
                        else if (header.GetType() == typeof (Header))
                        {
                            Hdr = (Header) header;
                            Custid = DataFix.FixInt(Hdr.m_objUsr.ID);
                             
                        }
                        else if(header.GetType() == typeof(Configuration))
                        {
                            configHdr = (ConfigurationAPHeader) header;
                            
                        }
                    }
