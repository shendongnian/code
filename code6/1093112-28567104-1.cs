    using System;
    using Xamarin.Forms;
    using System.Threading;
    [assembly:Dependency(typeof(YourNamespaceHere.PlatformCultureInfo))]
    namespace YourNamespaceHere
    {
        public class PlatformCultureInfo : ICultureInfo
        {
            #region ICultureInfo implementation
            public System.Globalization.CultureInfo CurrentCulture {
                get {
                    return Thread.CurrentThread.CurrentCulture;
                }
                set {
                    Thread.CurrentThread.CurrentCulture = value;
                }
            }
            public System.Globalization.CultureInfo CurrentUICulture {
                get {
                    return Thread.CurrentThread.CurrentUICulture;
                }
                set {
                    Thread.CurrentThread.CurrentUICulture = value;
                }
            }
            #endregion
        }
    }
