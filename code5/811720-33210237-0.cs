     using System;
        using System.Windows;
        using System.Windows.Controls;
        
        namespace YourNameSpace
        {
            partial class OPButton
            {
                /// <summary>
                /// Create a custom routed event by first registering a RoutedEventID
                /// This event uses the bubbling routing strategy
                /// see the web page https://msdn.microsoft.com/EN-US/library/vstudio/ms598898(v=vs.90).aspx 
                /// </summary>
                public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OPButton));
                /// <summary>
                /// Provide CLR accessors for the event Click OPButton 
                /// Adds a routed event handler for a specified routed event Click, adding the handler to the handler collection on the current element.
                /// </summary>
                public event RoutedEventHandler Click
                {
                    add {AddHandler(ClickEvent, value); }
                    remove { RemoveHandler(ClickEvent, value); }
                }
                /// <summary>
                /// This method raises the Click event 
                /// </summary>
                private void RaiseClickEvent()
                {
                    RoutedEventArgs newEventArgs = new RoutedEventArgs(OPButton.ClickEvent);
                    RaiseEvent(newEventArgs);
                }
                /// <summary>
                /// For isPressed purposes we raise the event when the OPButton is clicked
                /// </summary>
                private void OnClick()
                {
                    RaiseClickEvent();
                }
            }
        }
