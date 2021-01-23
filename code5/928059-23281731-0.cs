    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;
    using SHDocVw;
    using mshtml;
    
    public class InternetExplorerInstance
    {
       public InternetExplorer Instance;
    
       public static InternetExplorerInstance GetCurrentInternetExplorerInstance()
       {
          InternetExplorer currentInternetExplorer = CurrentInternetExplorer();
          if ( currentInternetExplorer != null )
          {
             return new InternetExplorerInstance( currentInternetExplorer );
          }
          return null;
       }
    
       private InternetExplorerInstance( InternetExplorer ie )
       {
          Instance = ie;
       }
    
       public static void Iterate()
       {
          GetInternetExplorers();
       }
    
       private static IEnumerable<InternetExplorer> GetInternetExplorers()
       {
          ShellWindows shellWindows = new ShellWindowsClass();
          List<InternetExplorer> allExplorers = shellWindows.Cast<InternetExplorer>().ToList();
          IEnumerable<InternetExplorer> internetExplorers = allExplorers.Where( ie => Path.GetFileNameWithoutExtension( ie.FullName ).ToLower() == "iexplore" );
          return internetExplorers;
       }
    
       public static void LaunchNewPage( string url )
       {
          InternetExplorer internetExplorer = GetInternetExplorers().FirstOrDefault();
          if ( internetExplorer != null )
          {
             internetExplorer.Navigate2( url, 0x800 );
             WindowsApi.BringWindowToFront( (IntPtr) internetExplorer.HWND );
          }
          else
          {
             internetExplorer = new InternetExplorer();
             internetExplorer.Visible = true;
             internetExplorer.Navigate2( url );
             WindowsApi.BringWindowToFront((IntPtr) internetExplorer.HWND);
          }
    
       }
    }
