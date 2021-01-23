    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Net;
    using System.Windows.Forms;
    using System.Threading;
    using System.ComponentModel;
    using System.Web;
    
    using System.Security.Authentication;
    
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    using Microsoft.Win32;
    using System.Runtime.CompilerServices;
    using System.Security.Policy;
    
    
    
    namespace margot_report
    {
    
       
    
        [ComImport,
    Guid("00000112-0000-0000-C000-000000000046"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleObject
        {
            void SetClientSite(IOleClientSite pClientSite);
           
        }
    
    
        [ComImport,
    Guid("00000118-0000-0000-C000-000000000046"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleClientSite
        {
            void SaveObject();
            void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);
            void GetContainer(object ppContainer);
            void ShowObject();
            void OnShowWindow(bool fShow);
            void RequestNewObjectLayout();
        }
    
        [ComImport,
        GuidAttribute("6d5140c1-7436-11ce-8034-00aa006009fa"),
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown),
        ComVisible(false)]
        public interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryService(ref Guid guidService, ref Guid riid, out IntPtr
            ppvObject);
        }
    
    
    
    
        [ComImport]
        [Guid("79EAC9D0-BAF9-11CE-8C82-00AA004BA90B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IAuthenticate
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            void Authenticate(IntPtr phwnd,
             [MarshalAs(UnmanagedType.LPWStr)] ref string pszUsername,
             [MarshalAs(UnmanagedType.LPWStr)] ref string pszPassword);
        }
    
      
       
    
        class SelfAuthenticatingWebBrowser : WebBrowser, IOleClientSite, IAuthenticate, IServiceProvider
        {
            public static Guid IID_IAuthenticate = new Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b");
            public static Guid SID_IAuthenticate = new Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b");
            public const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
            public const int S_OK = unchecked((int)0x00000000);
    
           
              
               
           
    
            public void Authenticate(IntPtr phwnd, ref string pszUsername, ref string pszPassword)
            {
                Console.WriteLine("Authenticate");
    
                pszUsername = Program.username; //
                pszPassword = Program.password; // 
                //return S_OK;
               
            }
    
            public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
            {
                //Console.WriteLine("QueryService");
                int nRet = guidService.CompareTo(IID_IAuthenticate); // Zero returned if the compared objects are equal
                if (nRet == 0)
                {
                    nRet = riid.CompareTo(IID_IAuthenticate); // Zero returned if the compared objects are equal
                    if (nRet == 0)
                    {
                        ppvObject = Marshal.GetComInterfaceForObject(this,
                        typeof(IAuthenticate));
                        return S_OK;
                    }
                }
                ppvObject = new IntPtr();
                return INET_E_DEFAULT_ACTION;
            }
    
            public void SaveObject()
            {
                throw new NotImplementedException();
            }
    
            public void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk)
            {
                throw new NotImplementedException();
            }
    
            public void GetContainer(object ppContainer)
            {
                throw new NotImplementedException();
            }
    
            public void ShowObject()
            {
                throw new NotImplementedException();
            }
    
            public void OnShowWindow(bool fShow)
            {
                throw new NotImplementedException();
            }
    
            public void RequestNewObjectLayout()
            {
                throw new NotImplementedException();
            }
        
    public IComponent  Component
    {
    	get { throw new NotImplementedException(); }
    }
    
    public IContainer  Container
    {
    	get { throw new NotImplementedException(); }
    }
    
    public bool  DesignMode
    {
    	get { throw new NotImplementedException(); }
    }
    
    public string  Name
    {
    	  get 
    	{ 
    		throw new NotImplementedException(); 
    	}
    	  set 
    	{ 
    		throw new NotImplementedException(); 
    	}
    }
    
    
    }
       
    
    
        class Program 
        {
    
            static bool send = true, verbose=false, clicked=false, submitted=false;
            static int c = 0, t=0;
            public static string filename, report, username, password;
            
            /// <summary>
    /// The URLMON library contains this function, URLDownloadToFile, which is a way
    /// to download files without user prompts.  The ExecWB( _SAVEAS ) function always
    /// prompts the user, even if _DONTPROMPTUSER parameter is specified, for "internet
    /// security reasons".  This function gets around those reasons.
    /// </summary>
    /// <param name="pCaller">Pointer to caller object (AX).</param>
    /// <param name="szURL">String of the URL.</param>
    /// <param name="szFileName">String of the destination filename/path.</param>
    /// <param name="dwReserved">[reserved].</param>
    /// <param name="lpfnCB">A callback function to monitor progress or abort.</param>
    /// <returns>0 for okay.</returns>
    [DllImport("URLMON.DLL", EntryPoint = "URLDownloadToFileW", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
    public static extern int URLDownloadToFile(int pCaller, string srcURL,
        string dstFile, int Reserved, int CallBack);
    
    
    
    
            static void Main(string[] args)
            {
    
    
    
    
    //            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://site.domain.com/operations/reporting/report-run.asp?reportid=720");
    ////webRequest.Proxy = webProxy;
    
               string appname = Environment.GetCommandLineArgs()[0];
    
                 if (args.Count() < 1)
                {
                    Console.WriteLine("Type: \"{0}\" -h for help on usage.\n", appname);
                    return;
                }
    
                if (args.Count() > 0)
                    foreach (var s in args)
                        if (s.Contains("-h") || s.Contains("/h") || s.Contains("-?") || s.Contains("/?"))
                        {
                            Console.WriteLine("\nUsage: {0} [-rfupv] <values>\n", appname);
                            Console.WriteLine("\n -r report_link ");
                            Console.WriteLine(" -f output_file ");
                            Console.WriteLine(" -u username   ");
                            Console.WriteLine(" -p password   ");
                            Console.WriteLine(" -t time_delay - seconds to wait before sending key strokes");
                            Console.WriteLine(" -v                  verbose output to console (for debugging)");
                            Console.WriteLine(" -h|?                Display this info and exit.");
                            
                            return;
                        }
    
    
                try
                {
                    if (args.Any(x => x.Contains("-f")))
                    {
                        int i = 0;
                        while (!args[i].Contains("-f")) i++;
                        filename =args[i + 1];
                    }
                    else filename = "report.csv";
    
                    if (args.Any(x => x.Contains("-r")))
                    {
                        int i = 0;
                        while (!args[i].Contains("-r")) i++;
                        report = args[i + 1];
                    }
                    else report = "http://site.domain.com/operations/reporting/report-run.asp?reportid=720";
    
                    if (args.Any(x => x.Contains("-u")))
                    {
                        int i = 0;
                        while (!args[i].Contains("-u")) i++;
                        username = args[i + 1];
                    }
                    else username = "";
    
                     if (args.Any(x => x.Contains("-p")))
                    {
                        int i = 0;
                        while (!args[i].Contains("-p")) i++;
                        password = args[i + 1];
                    }
                    else password = "";
    
                     if (args.Any(x => x.Contains("-t")))
                     {
                         int i = 0;
                         while (!args[i].Contains("-t")) i++;
                         t = int.Parse(args[i + 1]);
                     }
                     else t = 5;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null) Console.WriteLine(ex.InnerException.Message);
                    return;
                }
    
                ///////////////////////////////
    
                //////////////////////////////////////////////////////
    
                Console.WriteLine("start");
                var th = new Thread(() => {
    
                //WebBrowser 
    
                    var wb = new SelfAuthenticatingWebBrowser();    // WebBrowser();
    
                   
    
                wb.Show(); Console.WriteLine(wb.DocumentText);
                Console.WriteLine(wb.DocumentText);
                wb.DocumentCompleted += browser_DocumentCompleted;
                wb.NewWindow += browser_newWindow; 
                wb.ControlAdded += browser_ControlAdded ;
                wb.LostFocus += browser_LostFocus;
                wb.Navigating += browser_Navigating;
                wb.FileDownload += browser_FileDownload;
                //wb.Site =  new MySitex();   
                //Console.WriteLine(wb.Site.GetService(typeof(IAuthenticateEx)));//wb.Site.Name
                
                Console.WriteLine(wb.AllowNavigation);
                    wb.Navigate("about:blank");
    
                    object obj = wb.ActiveXInstance;
                    IOleObject oc = obj as IOleObject;
                    oc.SetClientSite(wb as IOleClientSite);
                    //this.Site = this as ISite;
                    System.IntPtr ppvServiceProvider;
                    IServiceProvider sp = wb as IServiceProvider;
                    sp.QueryService(ref SelfAuthenticatingWebBrowser.SID_IAuthenticate, ref SelfAuthenticatingWebBrowser.IID_IAuthenticate, out ppvServiceProvider);               
                  
    
                wb.Navigate(report);
                       Application.Run();
                });
    
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
    
                Console.WriteLine("end");
            }
    
    
            static void browser_Navigating(object sender, EventArgs e)
            {
                Console.WriteLine("navigating..." );
                var s = sender as WebBrowser;
                Console.WriteLine(s.DocumentTitle + s.Name);
                //foreach (var x in s.Controls)
                //    Console.WriteLine(x.ToString());
                //foreach(Form x in Application.OpenForms)
                //    Console.WriteLine(x.Name);
                if (false)//(send)
                {
                    send = false;
                    var thekeys = new Thread(() =>
                    {
    
                        Thread.Sleep(t*1000);
    
                        if (username != "")
                        {
                            Console.WriteLine("sending username key strokes");
                            SendKeys.SendWait(username);
                            SendKeys.SendWait("{TAB}");
                            Console.WriteLine("sent");
                        }
    
                        if (password != "")
                        {
                            Console.WriteLine("sending password key strokes");
                            SendKeys.SendWait(password);
                            SendKeys.SendWait("{ENTER}");
                            Console.WriteLine("sent");
                        }
    
                    });
                    thekeys.Start();
                }
               
    
            }
    
            static void browser_FileDownload(object sender, EventArgs e)
            {
                if(verbose) Console.WriteLine("FileDownload : " + e.ToString());
                var s = sender as WebBrowser;
                if (verbose) Console.WriteLine(s.DocumentTitle + s.Name + s.Url); //Console.ReadKey();
            }
    
            static void browser_LostFocus(object sender, EventArgs e)
            {
                Console.WriteLine("lost focus : " + e.ToString());
                var s = sender as WebBrowser;
                Console.WriteLine(s.DocumentTitle + s.Name);
            }
            static void browser_ControlAdded(object sender, ControlEventArgs e)
            {
                Console.WriteLine("control added : " + e.ToString());
                var s = sender as WebBrowser;
                Console.WriteLine(s.DocumentTitle + s.Name);
            }
    
            static void browser_newWindow(object sender, CancelEventArgs e)
            {
                Console.WriteLine("new : " + e.ToString());
                var s = sender as WebBrowser;
                Console.WriteLine(s.DocumentTitle + s.Name);
            }
    
            static void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var br = sender as WebBrowser;
                if (e.Url.ToString()=="about:blank") return;
    
                if (br.Url == e.Url)
                {
                    Console.WriteLine("Navigated to {0}", e.Url);
    
                    if (e.Url.ToString() == "http://site.domain.com/operations/reporting/report-generate.asp") submitted = true;
                    if(verbose) Console.WriteLine(br.DocumentText);
                    //Console.WriteLine(br.Document.Cookie);
                    if(!clicked)
                    foreach (HtmlElement x in br.Document.All)
                    {
                       // if (x.All == null)
    
                        //Console.WriteLine("|{0} {1} {2}| [{3}]\n", x.Id, x.Name, ".",x.GetAttribute("value"));
                        if (x.Name == "format" && x.GetAttribute("value") == "C") { Console.WriteLine("\n C L I C K !\n"); x.InvokeMember("click"); Thread.Sleep(1000); clicked = true; }
                        
                        //else foreach (HtmlElement y in x.Document.All)
                          //      Console.WriteLine("|{0} {1} {2}| [{3}]\n", y.Id, y.Name, y.OuterHtml, x.InnerText);
                    }
    
                    if (clicked && !submitted)
                    {
                        Console.WriteLine("submitting the report");
    
    
                        if (verbose) Console.WriteLine(" function at: {0}", br.DocumentText.IndexOf("function runReport()"));
                        //var newtext = br.DocumentText.Replace("value=\"R\" checked", "value=\"R\" ").Replace("value=\"C\"", "value=\"C\" checked");
                        //Console.WriteLine(" function at: {0}", br.DocumentText.IndexOf("function runReport()"));
                        
                        br.Document.InvokeScript("runReport");
                        
                        Console.WriteLine("done");
    
                        //Console.WriteLine(br.DocumentText);
                        
                    }
    
                    //if (c == 1)
                    {
                        //Console.WriteLine(br.DocumentText);
                        if (verbose) Console.WriteLine(br.DocumentText.IndexOf("http://"));
                        if (verbose) Console.WriteLine(br.DocumentText.IndexOf(".csv"));
                        
                    }
    
                    if (verbose) Console.WriteLine("c = {0}", c);
    
                    //http://site.domain.com/operations/reporting/csv/Report714_4045373.csv
                    if (submitted)
                    {
                        int start = br.DocumentText.IndexOf("csv/Report");
    
                        int end = 0; if (start >= 0) end = br.DocumentText.IndexOf(".csv", start);
    
                        if (start > 0 && end > start)
                        {
                            if (verbose) Console.WriteLine(br.DocumentText.Substring(start, end - start));
                            string link = "http://site.domain.com/operations/reporting/" + br.DocumentText.Substring(start, end - start) + ".csv";
                            Console.WriteLine(link);
    
                            //Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                            //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
    
                            if (URLDownloadToFile(0, link, filename, 0, 0) == 0)
                                Console.WriteLine("The report has been saved as {0}", filename);
                            else
                                Console.WriteLine("There was a problem with downloading/saving the report {0}", report);
    
                            Application.ExitThread();
                            
                        }
                    }
                    if (verbose) Console.WriteLine("cookies ? {0}, {1}, {2}", br.Document.Cookie == null, br.Document.Cookie == "", br.Document.Cookie);
                    c++;
                    if(c>4) Application.ExitThread();   // Stops the thread
                }
            }
    
            
        }
    
    
    }
