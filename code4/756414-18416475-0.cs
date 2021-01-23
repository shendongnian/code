    using System;
    using System.Reflection;
    public class Program
    {
        public static void Main(string[] args)
        {
            object o = new CustomArgsTransmitter();
            
            // make sure we've got the interface
            var interf = o.GetType().GetInterface("ICustomTransmitter`1");
            
            // get the arg type.
            var argType = interf.GetGenericArguments()[0];
            
            // create a delegate for the handler based on the arg type above
            var handlerMethodInfo = typeof(Program).GetMethod("Handler", BindingFlags.Static | BindingFlags.Public)
            var del = Delegate.CreateDelegate(typeof(EventHandler<>).MakeGenericType(argType), handlerMethodInfo);
            
            // Invoke the add method of the event.
            o.GetType().InvokeMember("add_DataEvent", BindingFlags.InvokeMethod, null, o, new object[] { del });
            
            //  just test code at this point.
            // fire event to make sure it is signed up.
            // It should print a message to the console.
            ((CustomArgsTransmitter)o).FireEvent();
            
        }
        
        public static void Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Got event {0} from {1}", e, sender);
        }
    }
    
    public interface IDataTransmitter { }
    
    public interface ICustomTransmitter<T> : IDataTransmitter where T : EventArgs
    {
        event EventHandler<T> DataEvent;
    }
    
    public class MyArgs : EventArgs { }
    
    public class CustomArgsTransmitter : ICustomTransmitter<MyArgs>
    {
        public event EventHandler<MyArgs> DataEvent;
        
        public void FireEvent()
        {
            DataEvent(this, new MyArgs());
        }
    }
