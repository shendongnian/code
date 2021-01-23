    public interface IBackwardCompatibilitySerializer
    {
        void OnUnknownElementFound(string uknownName, string value);
    }
    private static void x_UnknownElement(object sender, XmlElementEventArgs xmlElementEventArgs)
    {
        var deserializedObject = (xmlElementEventArgs.ObjectBeingDeserialized as IBackwardCompatibilitySerializer);
        if (deserializedObject == null) return;
        deserializedObject.OnUnknownElementFound(xmlElementEventArgs.Element.Name, xmlElementEventArgs.Element.InnerText);
    }
