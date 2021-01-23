        private void PopulateReferencedButMissingAssemblies(List<string> listOfKnowAssymblies)
        {
            HashSet<string> missingRefs = new HashSet<string>();
            foreach (string assemblyName in listOfKnowAssymblies)
            {
                Assembly parent = Assembly.Load(assemblyName);
                AssemblyName[] refs = parent.GetReferencedAssemblies();
                foreach (AssemblyName d in refs) //checking references
                {
                    try
                    {
                        Assembly subRef = Assembly.Load(d.FullName);
                        subRef = null; //release loaded assembly
                    }
                    catch
                    {
                        missingRefs.Add(d.FullName);
                    }
                }
            }
            if (missingRefs.Count == 0)
            {
                //refsPanel.Visible = false;
                //return;
            }
            foreach (string mref in missingRefs)
            {
                //display missing refs in my case
            }
        }
