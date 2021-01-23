    XNamespace ns = "http://www.nwpp.org/eide";
    var query1 = doc.Descendants(ns +"MessageInfo").Select(s => new MessageInfo
                                 {
                                     SYSGENID = s.Element(ns +"SysGenID").Value,
                                     TIME_STAMP = s.Element(ns +"TimeStamp").Value,
                                     SENDER = s.Element(ns +"Sender").Value,
                                     RECEIVER = s.Element(ns +"Receiver").Value,
                                    ENTITY_CODE = s.Element(ns +"EntityCode").Value
                                 }).FirstOrDefault();
