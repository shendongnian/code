    public ServerWinProcessor(string serverAddress)
      : base(serverAddress)
    {
    }
    [DllImport("mpr.dll")]
    public static extern int WNetAddConnection2(ref NETRESOURCE netResource, string password, string username, uint flags);
    [DllImport("mpr.dll")]
    public static extern int WNetCancelConnection2(string lpName, int dwFlags, bool fForce);
    [DllImport("mpr.dll")]
    public static extern int WNetOpenEnum(int dwScope, int dwType, int dwUsage, NETRESOURCE2 lpNetResource, out IntPtr lphEnum);
    [DllImport("Mpr.dll", EntryPoint = "WNetCloseEnum", CallingConvention = CallingConvention.Winapi)]
    private static extern int WNetCloseEnum(IntPtr hEnum);
    [DllImport("mpr.dll")]
    private static extern int WNetEnumResource(IntPtr hEnum, ref uint lpcCount, IntPtr buffer, ref uint lpBufferSize);
    public OperationResult LoginToNetworkShare(string userName, string password, string shareName)
    {
      return LoginToNetworkShare(userName, password, shareName, null);
    }
    public OperationResult LoginToNetworkShare(string userName, string password, string shareName, string shareDrive)
    {
      NETRESOURCE nr = new NETRESOURCE();
      nr.dwType = RESOURCETYPE_DISK;
      nr.lpLocalName = shareDrive;
      nr.lpRemoteName = @"\\" + ServerAddress + @"\" + shareName;
      int result = WNetAddConnection2(ref nr, password, userName, CONNECT_TEMPORARY);
      return new OperationResult(result);
    }
    public Task<OperationResult> LoginToNetworkShareAsync(string userName, string password, string shareName, string shareDrive)
    {
      return Task.Factory.StartNew(() =>
      {
        return LoginToNetworkShare(userName, password, shareName, shareDrive);
      });
    }
    public OperationResult LogoutFromNetworkSharePath(string sharePath)
    {
      int result = WNetCancelConnection2(sharePath, CONNECT_UPDATE_PROFILE, true);
      return new OperationResult(result);
    }
    public OperationResult LogoutFromNetworkShare(string shareName)
    {
      int result = WNetCancelConnection2(@"\\" + ServerAddress + @"\" + shareName, CONNECT_UPDATE_PROFILE, true);
      return new OperationResult(result);
    }
    public OperationResult LogoutFromNetworkShareDrive(string driveLetter)
    {
      int result = WNetCancelConnection2(driveLetter, CONNECT_UPDATE_PROFILE, true);
      return new OperationResult(result);
    }
    private ArrayList EnumerateServers(NETRESOURCE2 pRsrc, int scope, int type, int usage, ResourceDisplayType displayType)
    {
      ArrayList netData = new ArrayList();
      ArrayList aData = new ArrayList();
      uint bufferSize = 16384;
      IntPtr buffer = Marshal.AllocHGlobal((int)bufferSize);
      IntPtr handle = IntPtr.Zero;
      int result;
      uint cEntries = 1;
      result = WNetOpenEnum(scope, type, usage, pRsrc, out handle);
      if (result == NO_ERROR)
      {
        do
        {
          result = WNetEnumResource(handle, ref cEntries, buffer, ref bufferSize);
          if (result == NO_ERROR)
          {
            Marshal.PtrToStructure(buffer, pRsrc);
            if (string.IsNullOrWhiteSpace(pRsrc.lpLocalName) == false && pRsrc.lpRemoteName.Contains(ServerAddress))
              if (aData.Contains(pRsrc.lpLocalName) == false)
              {
                aData.Add(pRsrc.lpLocalName);
                netData.Add(new NetworkConnectionInfo(null, pRsrc.lpLocalName));
              }
            if (aData.Contains(pRsrc.lpRemoteName) == false && pRsrc.lpRemoteName.Contains(ServerAddress))
            {
              aData.Add(pRsrc.lpRemoteName);
              netData.Add(new NetworkConnectionInfo(pRsrc.lpRemoteName, null));
            }
            if ((pRsrc.dwUsage & RESOURCEUSAGE_CONTAINER) == RESOURCEUSAGE_CONTAINER)
              netData.AddRange(EnumerateServers(pRsrc, scope, type, usage, displayType));
          }
          else if (result != ERROR_NO_MORE_ITEMS)
            break;
        } while (result != ERROR_NO_MORE_ITEMS);
        WNetCloseEnum(handle);
      }
      Marshal.FreeHGlobal(buffer);
      return netData;
    }
    public void CloseAllConnections()
    {
      NETRESOURCE2 res = new NETRESOURCE2();
      ArrayList aData = EnumerateServers(res, RESOURCE_CONNECTED, 0, 0, ResourceDisplayType.RESOURCEDISPLAYTYPE_NETWORK);
      foreach (NetworkConnectionInfo item in aData)
      {
        if (item.IsRemoteOnly)
          LogoutFromNetworkSharePath(item.RemoteName);
        else
          LogoutFromNetworkShareDrive(item.LocalName);
      }
    }
    }
