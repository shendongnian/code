    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies().Where(a=>!a.FullName.StartsWith("System.") || !a.FullName.StartsWith("Microsoft.")))
                {
                    var types = a.GetTypes().Where(t => (typeof(Form).IsAssignableFrom(t) || typeof(UserControl).IsAssignableFrom(t) )&& t.IsClass && t.FullName.StartsWith("YourNamespace."));
                    
                    
                }
