    public class ElementAdder
    {
        public static void WriteToDoc(string path, XElement element)
        {
            // load doc based on path   
            // add element to doc
        }
    }
    public void OnButton1Click(object sender, RoutedEventArgs e)
    {
        // do something with element
        string path = ConfigMan.GetDocPath();
        ElementAdder.WriteToDoc(path, myNewElement);
    }
    public void OnButton2Click(object sender, RoutedEventArgs e)
    {
        // do something else with element
        string path = ConfigMan.GetDocPath();
        ElementAdder.WriteToDoc(path, myNewElement);
    }
