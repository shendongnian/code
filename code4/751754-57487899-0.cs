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
                    Method(Client);
                }
                finally
                {
                    try
                    {
                        if (Client.IsNotNothing)
                        {
                            if (Client.State == CommunicationState.Faulted)
                                Client.Abort();
                            else
                                Client.Close();
                        }
                    }
                    catch (CommunicationException ex)
                    {
                        Client.Abort();
                    }
                    catch (TimeoutException ex)
                    {
                        Client.Abort();
                    }
                    catch (Exception ex)
                    {
                        Client.Abort();
                        throw new Exception(ex.Message, ex);
                    }
                    finally
                    {
                        Client = null;
                    }
                }
            }
            [DebuggerStepThrough]
            public static TResult Call<TChannel, TResult>(this TChannel Client, Func<TChannel, TResult> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    return Method(Client);
                }
                finally
                {
                    try
                    {
                        if (Client.IsNotNothing)
                        {
                            if (Client.State == CommunicationState.Faulted)
                                Client.Abort();
                            else
                                Client.Close();
                        }
                    }
                    catch (CommunicationException ex)
                    {
                        Client.Abort();
                    }
                    catch (TimeoutException ex)
                    {
                        Client.Abort();
                    }
                    catch (Exception ex)
                    {
                        Client.Abort();
                        throw new Exception(ex.Message, ex);
                    }
                    finally
                    {
                        Client = null;
                    }
                }
            }
            [DebuggerStepThrough]
            public async static Task CallAsync<TChannel>(this TChannel Client, Func<TChannel, Task> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    await Method(Client);
                }
                finally
                {
                    try
                    {
                        if (Client.IsNotNothing)
                        {
                            if (Client.State == CommunicationState.Faulted)
                                Client.Abort();
                            else
                                Client.Close();
                        }
                    }
                    catch (CommunicationException ex)
                    {
                        Client.Abort();
                    }
                    catch (TimeoutException ex)
                    {
                        Client.Abort();
                    }
                    catch (Exception ex)
                    {
                        Client.Abort();
                        throw new Exception(ex.Message, ex);
                    }
                    finally
                    {
                        Client = null;
                    }
                }
            }
            [DebuggerStepThrough]
            public async static Task<TResult> CallAsync<TChannel, TResult>(this TChannel Client, Func<TChannel, Task<TResult>> Method) where TChannel : ICommunicationObject
            {
                try
                {
                    return await Method(Client);
                }
                finally
                {
                    try
                    {
                        if (Client.IsNotNothing)
                        {
                            if (Client.State == CommunicationState.Faulted)
                                Client.Abort();
                            else
                                Client.Close();
                        }
                    }
                    catch (CommunicationException ex)
                    {
                        Client.Abort();
                    }
                    catch (TimeoutException ex)
                    {
                        Client.Abort();
                    }
                    catch (Exception ex)
                    {
                        Client.Abort();
                        throw new Exception(ex.Message, ex);
                    }
                    finally
                    {
                        Client = null;
                    }
                }
            }
        }
    }
