    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace SpacemonsterIndustries.Core
    {
        public static class EventExtensions
        {
            /// <summary>
            /// Extension Method that converts a typical EventArgs Event into an awaitable Task 
            /// </summary>
            /// <typeparam name="TEventArgs">The type of the EventArgs (must inherit from EventArgs)</typeparam>
            /// <param name="objectWithEvent">the object that has the event</param>
            /// <param name="trigger">optional Function that triggers the event</param>
            /// <param name="eventName">the name of the event -> use nameof to be safe, e.g. nameof(button.Click) </param>
            /// <param name="ct">an optional Cancellation Token</param>
            /// <returns></returns>
            public static async Task<TEventArgs> EventAsync<TEventArgs>(this object objectWithEvent, Action trigger, string eventName, CancellationToken ct = default)
                where TEventArgs : EventArgs
            {
                var completionSource = new TaskCompletionSource<TEventArgs>(ct);
                var eventInfo = objectWithEvent.GetType().GetEvent(eventName);
                var delegateDef = new UniversalEventDelegate<TEventArgs>(Handler);
                var handlerAsDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, delegateDef.Target, delegateDef.Method);
                
                eventInfo.AddEventHandler(objectWithEvent, handlerAsDelegate);
                
                trigger?.Invoke();
    
                var result = await completionSource.Task;
                
                eventInfo.RemoveEventHandler(objectWithEvent, handlerAsDelegate); 
                
                return result;
    
                void Handler(object sender, TEventArgs e) => completionSource.SetResult(e);
            }
    
            public static Task<TEventArgs> EventAsync<TEventArgs>(this object objectWithEvent, string eventName, CancellationToken ct = default) where TEventArgs : EventArgs
                => EventAsync<TEventArgs>(objectWithEvent, null, eventName, ct);
            
            private delegate void UniversalEventDelegate<in TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;
        }
    }
