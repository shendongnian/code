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
    namespace Intexx.ServiceModel
    {
        public static class WcfExtensions
        {
            [DebuggerStepThrough]
            public static void Call<TChannel>(this TChannel Client, Action<TChannel> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    Method.Invoke(Client);
                }
                finally
                {
                    Cleanup(Client);
                }
            }
            [DebuggerStepThrough]
            public static TResult Call<TChannel, TResult>(this TChannel Client, Func<TChannel, TResult> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    return Method.Invoke(Client);
                }
                finally
                {
                    Cleanup(Client);
                }
            }
            [DebuggerStepThrough]
            public async static Task CallAsync<TChannel>(this TChannel Client, Func<TChannel, Task> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    await Method.Invoke(Client);
                }
                finally
                {
                    Cleanup(Client);
                }
            }
            [DebuggerStepThrough]
            public async static Task<TResult> CallAsync<TChannel, TResult>(this TChannel Client, Func<TChannel, Task<TResult>> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    return await Method.Invoke(Client);
                }
                finally
                {
                    Cleanup(Client);
                }
            }
            private static void Cleanup<TChannel>(TChannel Client) where TChannel : ICommunicationObject
            {
                try
                {
                    if (Client.IsNotNull)
                    {
                        if (Client.State == CommunicationState.Faulted)
                            Client.Abort();
                        else
                            Client.Close();
                    }
                }
                catch (Exception ex)
                {
                    Client.Abort();
                    if (!ex is CommunicationException && !ex is TimeoutException)
                        throw new Exception(ex.Message, ex);
                }
                finally
                {
                    Client = null;
                }
            }
        }
    }
