    public static Type NewDelegateType(Type ret, params Type[] parameters) {
      /*
      Type[] args = new Type[parameters.Length];   // Create "args" array of same length as "parameters" (must be length + 1)
      parameters.CopyTo(args, 0);                  // Copy all values of parameters to "args" array
      args[args.Length - 1] = ret;                 // Put "ret" value to last item of "args" array
      return MakeNewCustomDelegate(args);
      */
      var offset = parameters.Length;
      Array.Resize(ref parameters, offset + 1);
      parameters[offset] = ret;
      return MakeNewCustomDelegate(parameters);
    }
