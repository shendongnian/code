                string original = @"<?xml version='1.0' encoding='utf-8'?>
                            <Root>
                              <Wigit>
                                <EditStamp UserId='timmy' Timestamp='2013-09-13T20:22:00' />
                                <Subnode1 Id='A' />
                              </Wigit>
                              <Wigit>
                                <EditStamp UserId='phil' Timestamp='2013-09-13T21:51:00' />
                                <Subnode1 Id='B' />
                              </Wigit>
                              <Wigit>
                                <EditStamp UserId='biff' Timestamp='2013-10-13T21:51:00' />
                                <Subnode1 Id='C' />
                              </Wigit>
                            </Root>";
            string update = @"<?xml version='1.0' encoding='utf-8'?>
                        <Root>
                          <Wigit>
                            <EditStamp UserId='frank' Timestamp='2010-10-13T22:00:00' />
                            <Subnode1 Id='A' />
                          </Wigit>
                        </Root>";
            XDocument docOriginal = XDocument.Parse(original);
            XDocument docUpdate = XDocument.Parse(update);
            var query = from o in docOriginal.Element("Root").Elements("Wigit")
                        from u in docUpdate.Element("Root").Elements("Wigit")
                        let x = docUpdate.Element("Root")
                                         .Elements("Wigit")
                                         .SingleOrDefault(e => e.Element("Subnode1").Attribute("Id").Value ==
                                                               o.Element("Subnode1").Attribute("Id").Value &&
                                                               (DateTime.Parse(e.Element("EditStamp").Attribute("Timestamp").Value) >
                                                                DateTime.Parse(o.Element("EditStamp").Attribute("Timestamp").Value)
                                                                )
                                                          ) ?? o
                        select x;
            XDocument merged = new XDocument(new XElement("Root", query));
            Console.WriteLine(merged.ToString());
