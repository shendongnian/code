      using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using System.Reflection;
    using System.Windows;
    
    namespace yournamespace
    {
     public class CommandBehaviorBinding : IDisposable
        {
            #region Properties
            /// <summary>
            /// Get the owner of the CommandBinding ex: a Button
            /// This property can only be set from the BindEvent Method
            /// </summary>
            public DependencyObject Owner { get; private set; }
            /// <summary>
            /// The event name to hook up to
            /// This property can only be set from the BindEvent Method
            /// </summary>
            public string EventName { get; private set; }
            /// <summary>
            /// The event info of the event
            /// </summary>
            public EventInfo Event { get; private set; }
            /// <summary>
            /// Gets the EventHandler for the binding with the event
            /// </summary>
            public Delegate EventHandler { get; private set; }
    
            #region Execution
            //stores the strategy of how to execute the event handler
            IExecutionStrategy strategy;
    
            /// <summary>
            /// Gets or sets a CommandParameter
            /// </summary>
            public object CommandParameter { get; set; }
    
            ICommand command;
            /// <summary>
            /// The command to execute when the specified event is raised
            /// </summary>
            public ICommand Command
            {
                get { return command; }
                set
                {
                    command = value;
                    //set the execution strategy to execute the command
                    strategy = new CommandExecutionStrategy { Behavior = this };
                }
            }
    
            Action<object> action;
            /// <summary>
            /// Gets or sets the Action
            /// </summary>
            public Action<object> Action
            {
                get { return action; }
                set
                {
                    action = value;
                    // set the execution strategy to execute the action
                    strategy = new ActionExecutionStrategy { Behavior = this };
                }
            }
            #endregion
    
            #endregion
    
            //Creates an EventHandler on runtime and registers that handler to the Event specified
            public void BindEvent(DependencyObject owner, string eventName)
            {
                EventName = eventName;
                Owner = owner;
                Event = Owner.GetType().GetEvent(EventName, BindingFlags.Public | BindingFlags.Instance);
                if (Event == null)
                    throw new InvalidOperationException(String.Format("Could not resolve event name {0}", EventName));
    
                //Create an event handler for the event that will call the ExecuteCommand method
                EventHandler = EventHandlerGenerator.CreateDelegate(
                    Event.EventHandlerType, typeof(CommandBehaviorBinding).GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance), this);
                //Register the handler to the Event
                Event.AddEventHandler(Owner, EventHandler);
            }
    
            /// <summary>
            /// Executes the strategy
            /// </summary>
            public void Execute()
            {
               
                strategy.Execute(CommandParameter);
            }
    
            #region IDisposable Members
            bool disposed = false;
            /// <summary>
            /// Unregisters the EventHandler from the Event
            /// </summary>
            public void Dispose()
            {
                if (!disposed)
                {
                    Event.RemoveEventHandler(Owner, EventHandler);
                    disposed = true;
                }
            }
    
            #endregion
        }
    }
    CommandBehavior.cs  :
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    
    namespace yournamespace
    {
      public  class CommandBehavior
        {
    
            #region Behavior
    
            /// <summary>
            /// Behavior Attached Dependency Property
            /// </summary>
            private static readonly DependencyProperty BehaviorProperty =
                DependencyProperty.RegisterAttached("Behavior", typeof(CommandBehaviorBinding), typeof(CommandBehavior),
                    new FrameworkPropertyMetadata((CommandBehaviorBinding)null));
    
            /// <summary>
            /// Gets the Behavior property. 
            /// </summary>
            private static CommandBehaviorBinding GetBehavior(DependencyObject d)
            {
                return (CommandBehaviorBinding)d.GetValue(BehaviorProperty);
            }
    
            /// <summary>
            /// Sets the Behavior property.  
            /// </summary>
            private static void SetBehavior(DependencyObject d, CommandBehaviorBinding value)
            {
                d.SetValue(BehaviorProperty, value);
            }
    
            #endregion
    
            #region Command
    
            /// <summary>
            /// Command Attached Dependency Property
            /// </summary>
            public static readonly DependencyProperty CommandProperty =
                DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandBehavior),
                    new FrameworkPropertyMetadata((ICommand)null,
                        new PropertyChangedCallback(OnCommandChanged)));
    
            /// <summary>
            /// Gets the Command property.  
            /// </summary>
            public static ICommand GetCommand(DependencyObject d)
            {
                return (ICommand)d.GetValue(CommandProperty);
            }
    
            /// <summary>
            /// Sets the Command property. 
            /// </summary>
            public static void SetCommand(DependencyObject d, ICommand value)
            {
                d.SetValue(CommandProperty, value);
            }
    
            /// <summary>
            /// Handles changes to the Command property.
            /// </summary>
            private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                CommandBehaviorBinding binding = FetchOrCreateBinding(d);
                binding.Command = (ICommand)e.NewValue;
            }
    
            #endregion
    
            #region Action
    
            /// <summary>
            /// Action Attached Dependency Property
            /// </summary>
            public static readonly DependencyProperty ActionProperty =
                DependencyProperty.RegisterAttached("Action", typeof(Action<object>), typeof(CommandBehavior),
                    new FrameworkPropertyMetadata((Action<object>)null,
                        new PropertyChangedCallback(OnActionChanged)));
    
            /// <summary>
            /// Gets the Action property.  
            /// </summary>
            public static Action<object> GetAction(DependencyObject d)
            {
                return (Action<object>)d.GetValue(ActionProperty);
            }
    
            /// <summary>
            /// Sets the Action property. 
            /// </summary>
            public static void SetAction(DependencyObject d, Action<object> value)
            {
                d.SetValue(ActionProperty, value);
            }
    
            /// <summary>
            /// Handles changes to the Action property.
            /// </summary>
            private static void OnActionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                CommandBehaviorBinding binding = FetchOrCreateBinding(d);
                binding.Action = (Action<object>)e.NewValue;
            }
    
            #endregion
    
            #region CommandParameter
    
            /// <summary>
            /// CommandParameter Attached Dependency Property
            /// </summary>
            public static readonly DependencyProperty CommandParameterProperty =
                DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandBehavior),
                    new FrameworkPropertyMetadata((object)null,
                        new PropertyChangedCallback(OnCommandParameterChanged)));
    
            /// <summary>
            /// Gets the CommandParameter property.  
            /// </summary>
            public static object GetCommandParameter(DependencyObject d)
            {
                return (object)d.GetValue(CommandParameterProperty);
            }
    
            /// <summary>
            /// Sets the CommandParameter property. 
            /// </summary>
            public static void SetCommandParameter(DependencyObject d, object value)
            {
                d.SetValue(CommandParameterProperty, value);
            }
    
            /// <summary>
            /// Handles changes to the CommandParameter property.
            /// </summary>
            private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                CommandBehaviorBinding binding = FetchOrCreateBinding(d);
                binding.CommandParameter = e.NewValue;
            }
    
            #endregion
    
            #region Event
    
            /// <summary>
            /// Event Attached Dependency Property
            /// </summary>
            public static readonly DependencyProperty EventProperty =
                DependencyProperty.RegisterAttached("Event", typeof(string), typeof(CommandBehavior),
                    new FrameworkPropertyMetadata((string)String.Empty,
                        new PropertyChangedCallback(OnEventChanged)));
    
            /// <summary>
            /// Gets the Event property.  This dependency property 
            /// indicates ....
            /// </summary>
            public static string GetEvent(DependencyObject d)
            {
                return (string)d.GetValue(EventProperty);
            }
    
            /// <summary>
            /// Sets the Event property.  This dependency property 
            /// indicates ....
            /// </summary>
            public static void SetEvent(DependencyObject d, string value)
            {
                d.SetValue(EventProperty, value);
            }
    
            /// <summary>
            /// Handles changes to the Event property.
            /// </summary>
            private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                CommandBehaviorBinding binding = FetchOrCreateBinding(d);
                //check if the Event is set. If yes we need to rebind the Command to the new event and unregister the old one
                if (binding.Event != null && binding.Owner != null)
                    binding.Dispose();
                //bind the new event to the command
                binding.BindEvent(d, e.NewValue.ToString());
            }
    
            #endregion
    
            #region Helpers
            //tries to get a CommandBehaviorBinding from the element. Creates a new instance if there is not one attached
            private static CommandBehaviorBinding FetchOrCreateBinding(DependencyObject d)
            {
                CommandBehaviorBinding binding = CommandBehavior.GetBehavior(d);
                if (binding == null)
                {
                    binding = new CommandBehaviorBinding();
                    CommandBehavior.SetBehavior(d, binding);
                }
                return binding;
            }
            #endregion
    
        }
    }
