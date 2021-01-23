    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    namespace Reader
    {
        public class Client
        {
            public static CemReaderClient Create()
            {
                Tuple<Channels.Binding, EndpointAddress, double> oService;
                try
                {
                    oService = Main.Services(typeof(ICemReader));
                    return new CemReaderClient(oService.Item1, oService.Item2);
                }
                catch (KeyNotFoundException ex)
                {
                    return null;
                }
            }
        }
    }
