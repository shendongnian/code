    internal class DurationCalculatorAspect : IMessageSink
    {
       public bool ExceptionHandlingEnabled { get; set; }
        internal DurationCalculatorAspect(IMessageSink next,bool exceptionHandlingEnabled)
        {
            m_next = next;
            ExceptionHandlingEnabled = exceptionHandlingEnabled;
        }
        private IMessageSink m_next;
        #region IMessageSink implementation
        public IMessageSink NextSink
        {
            
            get { return m_next; }
        }
        public IMessage SyncProcessMessage(IMessage msg)
        {
            var typeResolver = ((System.Type[])(((System.Collections.ArrayList)msg.Properties.Values)[2]));
            var typeName = "void";
            if(typeResolver.Count()!=0)
            {
                typeName = typeResolver[0].FullName;
            }
            var argsString = "";
            var argArray =(object[])((System.Collections.ArrayList)msg.Properties.Values)[4];
            for (int i = 0;i<argArray.Length;i++)
            {
                argsString+=(i+1).ToString() + ". Object : " +argArray[i];
            }
            Logger.GetLogger().Debug("MethodName : "+((System.Collections.ArrayList)msg.Properties.Values)[1]+"\r\n"+
                "TypeName: " + typeName + "\r\n" + "Args : " + argsString
                );
            var date1 = DateTime.Now;
            
            
          var  returnMethod =
            m_next.SyncProcessMessage(msg);
            var returnMessage = ((IMethodReturnMessage)returnMethod);
            
            var date2 = DateTime.Now;
            Logger.GetLogger().Debug("MethodName : " + returnMessage.MethodName + "Duration : " + date2.Subtract(date1).TotalMilliseconds + " .ms"+"\r\n"+
                "TypeName: " + typeName + "\r\nReturned : " +returnMessage.ReturnValue);
            if (returnMessage.Exception != null)
            {
                Logger.GetLogger().Fatal("Exception : " + returnMessage.Exception.Data + " InnerException : " + returnMessage.Exception.InnerException);
                if (ExceptionHandlingEnabled)
                {
                    return new ReturnMessage(null, null);
                }
            }
            return returnMethod;
        }
        public IMessageCtrl AsyncProcessMessage(IMessage msg,
        IMessageSink replySink)
        {
            throw new InvalidOperationException();
        }
        #endregion //IMessageSink implementation
    }
    public class DurationCalculatorInterceptorProperty : IContextProperty,
    IContributeObjectSink
    {
        public bool ExceptionHandlingEnabled { get; set; }
        public DurationCalculatorInterceptorProperty(bool exceptionHandlingEnabled)
        {
            ExceptionHandlingEnabled = exceptionHandlingEnabled;
        }
        #region IContributeObjectSink implementation
        public IMessageSink GetObjectSink(MarshalByRefObject o,
        IMessageSink next)
        {
            return new DurationCalculatorAspect(next,ExceptionHandlingEnabled);
        }
        #endregion // IContributeObjectSink implementation
        #region IContextProperty implementation
        // Implement Name, Freeze, IsNewContextOK
        #endregion //IContextProperty implementation
        public void Freeze(Context newContext)
        {
        }
        public bool IsNewContextOK(Context newCtx)
        {
            return true;
        }
        public string Name
        {
            get { return ""; }
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class DurationCalculatorInterceptorAttribute : ContextAttribute
    {
        public bool ExceptionHandlingEnabled { get; set; }
       
        public DurationCalculatorInterceptorAttribute(bool exceptionHandlingEnabled) : base("Security")
        {
            ExceptionHandlingEnabled = exceptionHandlingEnabled;
        }
        
        public override void GetPropertiesForNewContext(
        IConstructionCallMessage ccm)
        {
            ccm.ContextProperties.Add(new DurationCalculatorInterceptorProperty(ExceptionHandlingEnabled));
             
        }
    }
