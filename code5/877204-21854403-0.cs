    public bool VerifyStrongName(string assemblyPath, bool force)
    {
      if (string.IsNullOrEmpty(assemblyPath))
        throw new ArgumentException(string.Empty, "assemblyPath");
    
      var host = HostingInteropHelper.GetClrMetaHost<IClrMetaHost>();
    
      var bufferSize = 100;
      var version = new StringBuilder(bufferSize);
      var result = host.GetVersionFromFile(Assembly.GetExecutingAssembly().Location, version, ref bufferSize);
      if ((HResult)result != HResult.S_OK)
        throw new COMException("Error", result);
    
      IClrRuntimeInfo info = host.GetRuntime(version.ToString(), new Guid(IID.IClrRuntimeInfo)) as IClrRuntimeInfo;
      ICLRStrongName sn = info.GetInterface(new Guid(CLSID.ClrStrongName), new Guid(IID.IClrStrongName)) as ICLRStrongName;
      
      var verResult = sn.StrongNameSignatureVerificationEx(assemblyPath, Convert.ToByte(force));
      return Convert.ToBoolean(verResult);
    }
