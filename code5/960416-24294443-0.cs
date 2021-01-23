    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace DynamicSet
    {
        class Program
        {
            object DynamicSet; // can be null, one stored Event or a List/HashSet<Event> 
                               // depending on how many elements are needed.
    
            bool Contains(Event ev)
            {
                if( DynamicSet == null )
                {
                    return false;
                }
    
                var storedEvent = DynamicSet as Event;
                if (storedEvent != null)
                {
                    return Object.ReferenceEquals(ev, storedEvent);
                }
                var set = (HashSet<Event>)DynamicSet;
                return set.Contains(ev);
            }
    
            void AddEvent(Event ev)
            {
                if( DynamicSet == null )
                {
                    DynamicSet = ev;
                    return;
                }
    
                var hash = DynamicSet as HashSet<Event>;
                if( hash != null )
                {
                    hash.Add(ev);
                }
                else
                {
                    hash = new HashSet<Event>();
                    hash.Add((Event)DynamicSet);
                    DynamicSet = hash;
                }
            }
    
            static void Main(string[] args)
            {
                Program p = new Program();
                Event ev1 = new Event();
                Event ev2 = new Event();
    
                p.AddEvent(ev1);
                Debug.Assert(p.Contains(ev1));
                Debug.Assert(!p.Contains(ev2));
                p.AddEvent(ev1);
                Debug.Assert(p.Contains(ev1));
                Debug.Assert(!p.Contains(ev2));
    
                p.AddEvent(ev2);
                Debug.Assert(p.Contains(ev1));
                Debug.Assert(p.Contains(ev2));
    
            }
        }
    }
