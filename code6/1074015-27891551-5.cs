    /// <summary>
    /// Tells the program that the Assembly its Seeking is located in the Embedded resources By using the
    /// <see cref="Assembly.GetManifestResourceNames"/> Function To get All the Resources
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <remarks>Note that this event won't fire if the dll is in the same folder as the application (sometimes)</remarks>
    private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
    {
    	try {
    		//gets the main Assembly
    		dynamic parentAssembly = Assembly.GetExecutingAssembly();
    		//args.Name will be something like this
    		//[ MahApps.Metro, Version=1.1.3.81, Culture=en-US, PublicKeyToken=null ]
    		//so we take the name of the Assembly (MahApps.Metro) then add (.dll) to it
    		dynamic finalname = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
    		//here we search the resources for our dll and get the first match
    		dynamic ResourcesList = parentAssembly.GetManifestResourceNames();
    		string OurResourceName = null;
    		//(you can replace this with a LINQ extension like [Find] or [First])
    		for (int i = 0; i <= ResourcesList.Count - 1; i++) {
    			dynamic name = ResourcesList(i);
    			if (name.EndsWith(finalname)) {
    				//Get the name then close the loop to get the first occuring value
    				OurResourceName = name;
    				break; // TODO: might not be correct. Was : Exit For
    			}
    		}
    
    		if (!string.IsNullOrWhiteSpace(OurResourceName)) {
    			//get a stream representing our resource then load it as bytes
    			using (Stream stream = parentAssembly.GetManifestResourceStream(OurResourceName)) {
    				//in vb.net use [ New Byte(stream.Length - 1) ]
    				//in c#.net use [ new byte[stream.Length]; ]
    				byte[] block = new byte[stream.Length];
    				stream.Read(block, 0, block.Length);
    				return Assembly.Load(block);
    			}
    		} else {
    			return null;
    		}
    	} catch (Exception ex) {
    		return null;
    	}
    }
