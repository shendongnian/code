    public static List<AppDomain> GetAppDomains()
    {
        List<AppDomain> _IList = new List<AppDomain>();
        IntPtr enumHandle = IntPtr.Zero;
        CorRuntimeHostClass host = new mscoree.CorRuntimeHostClass();
        try
        {
            host.EnumDomains(out enumHandle);
            object domain = null;
            while (true)
            {
                host.NextDomain(enumHandle, out domain);
                if (domain == null) break;
                AppDomain appDomain = (AppDomain)domain;
                _IList.Add(appDomain);
            }
            return _IList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
        finally
        {
            host.CloseEnum(enumHandle);
            Marshal.ReleaseComObject(host);
        }
    }
