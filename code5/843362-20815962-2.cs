    var doc = XDocument.Load("xmldata.xml");
    var subjectNode = doc.Descendants("Name").FirstOrDefault(o => o.Value == SubjectId).Parent;
    textBox1.Text = subjectNode.Element("Name").Value;
    textBox2.Text = subjectNode.Element("TotalLectures").Value;
    textBox3.Text = subjectNode.Element("AttendedLectures").Value;
