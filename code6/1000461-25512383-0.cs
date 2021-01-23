    XDocument doc = ...;
    foreach (var step in doc.Root.Elements("Steps").Elements("Step"))
    {
         MessageBox.Show(string.Format("ID: {0} Desc: {1}",
                         step.Element("ID").Value, step.Element("desc").Value);
         foreach (var tool in step.Elements("tools"))
         {
             ...
         }
    }
