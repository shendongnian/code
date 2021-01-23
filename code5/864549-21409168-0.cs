    //ISapProxy.cs
    using System.Collections.Generic;
    using System.ServiceModel;
    
    namespace LibraryData
    {
        [ServiceContract]
        public interface ISapProxy
        {
            [OperationContract]
            List<SapData> QueryData(string query);
    
            [OperationContract]
            void Close();
        }
    }
    //SapProxy.cs
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace LibraryData
    {
        public class SapProxy : ISapProxy
        {
            public List<SapData> QueryData(string query)
            {
                Thread.Sleep(new TimeSpan(0, 0, 5)); //represents time + cpu intensive method
    
                return new List<SapData>();
            }
    
    
            public void Close()
            {
                Application.Exit();
            }
        }
    }
    //SapData.cs
    using System.Runtime.Serialization;
    
    namespace LibraryData
    {
        [DataContract]
        public class SapData
        {
        }
    }
