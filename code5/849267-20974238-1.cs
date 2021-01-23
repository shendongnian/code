    <?xml version="1.0" encoding="utf-8" ?>
    <Incidents>
      <Incident>
        <Contract>18</Contract>
        <SerialNo>0000000001</SerialNo>
        <EntryTime>2013-12-31T00:13:23</EntryTime>
        <ExitTime>2013-12-31T01:00:47</ExitTime>
        <Registration>LL5AVP</Registration>
        <Location>Middlesex</Location>
        <Comment>
          Entry Date: Tuesday, 31 12 2013 on 00:13:23
          Exit Date: Tuesday, 31 12 2013 on 01:00:47
        </Comment>
      </Incident>
      <Incident>
        <Contract>19</Contract>
        <SerialNo>0000000001</SerialNo>
        <EntryTime>2013-12-31T00:13:23</EntryTime>
        <ExitTime>2013-12-31T01:00:47</ExitTime>
        <Registration>LL5AVP</Registration>
        <Location>Middlesex</Location>
        <Comment>
          Entry Date: Tuesday, 31 12 2013 on 00:13:23
          Exit Date: Tuesday, 31 12 2013 on 01:00:47
        </Comment>
      </Incident>
      <Incident>
        <Contract>20</Contract>
        <SerialNo>0000000001</SerialNo>
        <EntryTime>2013-12-31T00:13:23</EntryTime>
        <ExitTime>2013-12-31T01:00:47</ExitTime>
        <Registration>LL5AVP</Registration>
        <Location>Middlesex</Location>
        <Comment>
          Entry Date: Tuesday, 31 12 2013 on 00:13:23
          Exit Date: Tuesday, 31 12 2013 on 01:00:47
        </Comment>
      </Incident>
      <Incident>
        <Contract>21</Contract>
        <SerialNo>0000000001</SerialNo>
        <EntryTime>2013-12-31T00:13:23</EntryTime>
        <ExitTime>2013-12-31T01:00:47</ExitTime>
        <Registration>LL5AVP</Registration>
        <Location>Middlesex</Location>
        <Comment>
          Entry Date: Tuesday, 31 12 2013 on 00:13:23
          Exit Date: Tuesday, 31 12 2013 on 01:00:47
        </Comment>
      </Incident>
    </Incidents>
--------------------
 
    XDocument xdoc1 = XDocument.Load(@"D:\xxxx\Xxxxxxx\xxxx\TrialXML.xml");
                    
      xdoc1.Root.Elements("Incident")
             .GroupBy(s => (string)s.Element("Comment"))
             .SelectMany(g => g.Skip(1)) 
             .Remove();
        
    xdoc1.Save(@"D:\xxxx\Xxxxxxx\xxxx\TrialXML.xml");         
 
