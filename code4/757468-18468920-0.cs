    [XmlRoot("FCS_SET_SCH")]
    public class DDCSendReceiveScheduleXml : IXmlSerializable
    {
         ...
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void WriteXml(XmlWriter writer)
        {
            Debug.Assert(ScheduleList.Count == TimeTableXmlList.Count, "ScheduleList and TimeTableXml Count isn't same");
            XmlSerializer scheduleSerializer = new XmlSerializer(typeof(ScheduleXml));
            XmlSerializer timeTableSerializer = new XmlSerializer(typeof(TimeTableXml));
            for (int i = 0; i < ScheduleList.Count; i++)
            {
                scheduleSerializer.Serialize(writer, ScheduleList[i]);
                timeTableSerializer.Serialize(writer, TimeTableXmlList[i]);
            }
        }
