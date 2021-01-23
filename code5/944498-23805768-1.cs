        public class CustomActions
        {
         private static readonly InstallerPropertiesFileManager InstallerPropertiesFileManager = new InstallerPropertiesFileManager();
        [CustomAction]
        public static ActionResult SetInstallerProperties(Session session)
        {
            session.Log("Begin SetInstallerProperties");
            try
            {
                
                var doc = XDocument.Load(@"C:\temp\Parameters.xml");
                session.Log("Parameters Loaded:" + (doc.Root != null));
                session.Log("Parameter Count:" + doc.Descendants("Parameter").Count());
                var parameters = doc.Descendants("Parameter").ToDictionary(n => n.Attribute("Name").Value, v => v.Attribute("Value").Value);
                if (parameters.Any())
                {
                    session.Log("Parameters loaded into Dictionary Count: " + parameters.Count());
                    //Set the Wix Properties in the Session object from the XML file
                    foreach (var parameter in parameters)
                    {
                        session[parameter.Key] = parameter.Value;
                    }
                }                
                else
                {
                    session.Log("No Parameters loaded");
                }
            }
            catch (Exception ex)
            {
                session.Log("ERROR in custom action SetInstallerProperties {0}", ex.ToString());
                return ActionResult.Failure;
            }
            session.Log("End SetInstallerProperties");
            return ActionResult.Success;
        }
        }
