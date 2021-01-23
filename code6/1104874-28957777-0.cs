    //Declare the object for return (if any)
    Student objWorkingObject = new Student();
    //Populate into XML
    XmlDocument _Doc = new XmlDocument();
    _Doc.LoadXml(strOrigObject);
    var ser = new System.Xml.Serialization.XmlSerializer(typeof(Student));
    objWorkingObject = (Student)ser.Deserialize(new XmlNodeReader(_Doc.DocumentElement));
