    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.ComponentModel;
    
    public class Async
    {
        public class DataByThreadWorker<T>
        {
            private BackgroundWorker bw = null;
            
            public delegate T GetDataDelegate();
            public GetDataDelegate getDataIns;
    
            public delegate void CallCompleted(T data);
            public CallCompleted dataCompletedIns;
    
            public delegate void DoSomething();
            public DoSomething doSomethingIns;
            public DoSomething doNexthingIns;
    
            public void DoAsync()
            {
                if (doSomethingIns != null)
                {
                    bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWorkVoid;
                    bw.RunWorkerCompleted += bw_RunWorkerVoidCompleted;
                    bw.RunWorkerAsync();
                }
                else
                {
                    throw new Exception("Ooops, doSomethingIns should not be null !!!");
                }
            }
    
            public void GetDataAsync()
            {
                if (getDataIns != null)
                {
                    bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWork;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync();
                }
                else
                {
                    throw new Exception("Ooops, getDataIns should not be null !!!");
                }
            }
    
            /*===========================================================================*/
    
            void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                if (getDataIns != null) e.Result = getDataIns();
            }
    
            void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (dataCompletedIns != null) dataCompletedIns((T)e.Result);
            }
            
            /*===========================================================================*/
    
            void bw_DoWorkVoid(object sender, DoWorkEventArgs e)
            {
                if (doSomethingIns != null) doSomethingIns(); 
                e.Result = true;
            }
    
            void bw_RunWorkerVoidCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (doNexthingIns != null) doNexthingIns();
            }
        }
    
        /*======================================================================================================================================================*/
    
        public static void GetDataAsync<T>(DataByThreadWorker<T>.GetDataDelegate GetDataFunc, DataByThreadWorker<T>.CallCompleted DataCompletedDelegate)
        {
            DataByThreadWorker<T> dt = new DataByThreadWorker<T>();
            dt.getDataIns = GetDataFunc;
            dt.dataCompletedIns = DataCompletedDelegate;
            dt.GetDataAsync();
        }
    
        public static void DoAsync(DataByThreadWorker<object>.DoSomething doSomethingIns, DataByThreadWorker<object>.DoSomething doNextthingIns)
        {
            DataByThreadWorker<object> dt = new DataByThreadWorker<object>();
            dt.doSomethingIns = doSomethingIns;
            dt.doNexthingIns = doNextthingIns;
            dt.DoAsync();
        }
    
    }
