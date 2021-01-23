    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BA_Lib
    {
        public class RTEventHandler<T>
        {
            private EventRegistrationTokenTable<EventHandler<T>> m_EventTokenTable = null;
            Dictionary<EventHandler<T>, EventRegistrationToken> _tokens = new Dictionary<EventHandler<T>, EventRegistrationToken>();
    
            public event EventHandler<T> Event
            {
                add
                {
                    if (_tokens.ContainsKey(value))
                        return;
                    var token = EventRegistrationTokenTable<EventHandler<T>>.GetOrCreateEventRegistrationTokenTable(ref m_EventTokenTable).AddEventHandler(value);
                    _tokens.Add(value, token);
                    return;
                }
                remove
                {
                    if (_tokens.ContainsKey(value))
                    {
                        var token = _tokens[value];
                        EventRegistrationTokenTable<EventHandler<T>>.GetOrCreateEventRegistrationTokenTable(ref m_EventTokenTable).RemoveEventHandler(token);
                        _tokens.Remove(value);
                    }
                }
            }
    
            public void Fire(T argument)
            {
                EventHandler<T> temp = EventRegistrationTokenTable<EventHandler<T>>.GetOrCreateEventRegistrationTokenTable(ref m_EventTokenTable).InvocationList;
                if (temp != null)
                    temp(null, argument);
            }
    
            public void Fire(object sender, T argument)
            {
                EventHandler<T> temp = EventRegistrationTokenTable<EventHandler<T>>.GetOrCreateEventRegistrationTokenTable(ref m_EventTokenTable).InvocationList;
                if (temp != null)
                    temp(sender, argument);
            }
        }
    }
