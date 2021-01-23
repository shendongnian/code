			/// <summary>
            /// This is the handler for failed assembly resolution attempts - when a failed resolve event fires, it will redirect the assembly lookup to internal 
            /// embedded resources. Not necessary for this method to ever be called by the user.
            /// </summary>
            /// <param name="sender">not important</param>
            /// <param name="args">automatically provided</param>
            /// <returns>returns the assembly once it is found</returns>
            private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
            {
                string[] toSplitWith = { "," };
                //New improvement - Allows for ANY DLL to be resolved to a local memory stream.
                bool bCompressed = true;
                string sFileName = args.Name.Split(toSplitWith, StringSplitOptions.RemoveEmptyEntries)[0] + ".dll";
                string sPath = "NameSpace.Resources.";
                Assembly thisAssembly = Assembly.GetExecutingAssembly(); //Gets the executing Assembly
                using (Stream input = thisAssembly.GetManifestResourceStream(sPath + sFileName)) // Acquire the dll from local memory/resources.
                {
            
                    return input != null ? Assembly.Load(StreamToBytes(input)) : null; // More bitwise operators - if input not Null, return the Assembly, else return null.
                }
            }
