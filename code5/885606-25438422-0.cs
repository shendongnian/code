	if (args.Length > 0)
	{
	    if (args.Contains<string>("--help"))
	    {
	        Console.WriteLine("appname [--debug] [--bootstrap <bootstrap name>]");
	        Console.WriteLine(" --debug       Runs \"appname\" in debug mode.")
	        Console.WriteLine(" --bootstrap   If no bootstrap name is provided the default \"AppName v1.2\" will be used.")
	        Console.WriteLine("")
	    }
	    //simple single argument passed to application
	    if (args.Contains<string>("--debug")) 
	    {
	        DEBUG_ON = true;
	        Console.WriteLine("Found argument: --debug");
	    }
	    //more complex relational argument passed to application
	    if (args.Contains<string>("--bootstrap")) 
	    {
	        int bootstrapLoc = Array.IndexOf<string>(args, "--bootstrap");
	        //always check that there is one more argument in the array
	        if(args.Length > bootstrapLoc + 1)
	        {
		        string bootstrapArg = args[bootstrapLoc + 1];
		        //this is where you would do your error checking against the second argument, ex: determine that it is what is expected
		        if (bootstrapArg != null && bootstrapArg != "")
		        {
		            this.MongoDBInstallName = bootstrapArg;
		            Console.WriteLine("Using the passed bootstrap arg: " + bootstrapArg);
		        }
	        }
	    }
	}
