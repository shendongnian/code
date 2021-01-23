    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace MyNamespace.Events
    {
        public class EventDriver : IDisposable
        {
            #region Supporting Events
            public List<EventResponse> FireEvent(String EventName, Event Event)
            {
                List<EventResponse> ResponseList = new List<EventResponse>();
    
                Type LocalType = this.GetType();
    
                Type TargetType = null;
    
                if ((TargetType = this.FindEventType(LocalType, EventName)) == null)
                {
                    return ResponseList;
                }
                else
                {
                    FieldInfo TargetField = TargetType.GetField(EventName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    
                    MulticastDelegate EventDelegates = (MulticastDelegate) TargetField.GetValue(this);
    
                    if (EventDelegates == null)
                    {
                        return ResponseList;
                    }
                    else
                    {
                        foreach (Delegate TargetDelegate in EventDelegates.GetInvocationList())
                        {
                            try
                            {
                                Object DelegateResponse = TargetDelegate.DynamicInvoke(new Object[] { Event });
                                EventResponse Response = (EventResponse)DelegateResponse;
                                ResponseList.Add(Response);
                            }
                            catch (Exception e)
                            {
                            }
                        }
    
                        return ResponseList;
                    }
                }
            }
    
            private Type FindEventType(Type RootType, String EventName)
            {
                if (RootType == null)
                {
                    return null;
                }
                else if (String.IsNullOrEmpty(EventName))
                {
                    return null;
                }
                else
                {
                    FieldInfo EventField = null;
    
                    foreach (FieldInfo Method in RootType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                        if (Method.Name == EventName)
                        {
                            EventField = Method;
                            break;
                        }
    
                    if (EventField == null)
                    {
                        if (RootType.BaseType == null)
                            return null;
                        else
                            return this.FindEventType(RootType.BaseType, EventName);
                    }
                    else
                    {
                        return RootType;
                    }
                }
            }
            #endregion
    
            #region Dispoability
            public virtual void Dispose()
            {
                this.FireEvent("OnDispose", new Event(this, "Object is being disposed."));
            }
            #endregion
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Reflection;
    
    namespace MyNamespace.Events
    {
        #region Delegates
        public delegate EventResponse EventHandler(Event Event);
        #endregion
    
        #region Enumerations
        public enum EventResponseType
        {
            Success, Failure
        }
        #endregion
    
        public class Event
        {
            #region Events
            public event EventHandler OnResponseFailure = null;
            #endregion
    
            #region Fields
            public Object EventSource = null;
    
            public DateTime EventTime = DateTime.Now;
    
            public String EventMessage = String.Empty;
    
            protected StackTrace _EventStackTrace = null;
    
            public StackTrace EventStackTrace
            {
                get
                {
                    return this._EventStackTrace;
                }
            }
    
            protected List<EventResponse> _EventResponses = null;
    
            public List<EventResponse> EventResponses
            {
                get
                {
                    List<EventResponse> EventResponses = new List<EventResponse>();
    
                    lock (this._EventResponses)
                    {
                        foreach (EventResponse Response in this._EventResponses)
                            EventResponses.Add(Response);
                    }
    
                    return EventResponses;
                }
            }
    
            public Boolean HasFailedResponses
            {
                get
                {
                    if (this.FailedResponses.Count > 0)
                        return true;
                    return false;
                }
            }
    
            public Boolean HasSuccessfulResponses
            {
                get
                {
                    if (this.SucceessfulResponses.Count > 0)
                        return true;
                    return false;
                }
            }
    
            public List<EventResponse> FailedResponses
            {
                get
                {
                    List<EventResponse> FailedResponses = new List<EventResponse>();
    
                    foreach (EventResponse Response in this.EventResponses)
                        if (Response.ResponseType == EventResponseType.Failure)
                            FailedResponses.Add(Response);
                    return FailedResponses;
                }
            }
    
            public List<EventResponse> SucceessfulResponses
            {
                get
                {
                    List<EventResponse> SucceededResponses = new List<EventResponse>();
    
                    foreach (EventResponse Response in this.EventResponses)
                        if (Response.ResponseType == EventResponseType.Success)
                            SucceededResponses.Add(Response);
                    return SucceededResponses;
                }
            }
    
            protected List<Event> _ForwardedEvents = null;
    
            public List<Event> ForwardedEvents
            {
                get
                {
                    List<Event> FowardedEvents = new List<Event>();
    
                    lock (this._ForwardedEvents)
                        foreach (Event ForwardedEvent in this.ForwardedEvents)
                            ForwardedEvents.Add(ForwardedEvent);
    
                    return ForwardedEvents;
                }
            }
            #endregion
    
            #region Constructors
            protected Event()
            {
                this._EventResponses = new List<EventResponse>();
                this._EventStackTrace = new StackTrace();
                this._ForwardedEvents = new List<Event>();
            }
    
            public Event(Object EventSource, String EventMessage, DateTime EventTime)
                : this()
            {
                this.EventSource = EventSource;
                this.EventTime = EventTime;
                this.EventMessage = EventMessage;
    
                return;
            }
    
            public Event(Object EventSource, String EventMessage)
                : this(EventSource, EventMessage, DateTime.Now)
            {
            }
            #endregion
    
            #region Supporting Methods
            public void AddResponse(EventResponse Response)
            {
                lock (this._EventResponses)
                {
                    this._EventResponses.Add(Response);
                }
    
                if (Response.ResponseType == EventResponseType.Failure)
                    this.TriggerResponseFailure(Response);
    
                return;
            }
    
            public EventResponse CreateResponse()
            {
                return new EventResponse(this);
            }
    
            public EventResponse CreateResponse(Object ResponseSource, Object ResponseObject, DateTime ResponseTime, String ResponseMessage, EventResponseType ResponseType)
            {
                return new EventResponse(this, ResponseSource, ResponseObject, ResponseTime, ResponseMessage, ResponseType);
            }
    
            public EventResponse CreateResponse(Object ResponseSource, Object ResponseObject, DateTime ResponseTime, EventResponseType ResponseType)
            {
                return this.CreateResponse(ResponseSource, ResponseObject, ResponseTime, String.Empty, ResponseType);
            }
    
            public EventResponse CreateResponse(Object ResponseSource, Object ResponseObject, DateTime ResponseTime)
            {
                return this.CreateResponse(ResponseSource, ResponseObject, ResponseTime, EventResponseType.Success);
            }
    
            public EventResponse CreateResponse(Object ResponseSource, Object ResponseObject, EventResponseType ResponseType)
            {
                return this.CreateResponse(ResponseSource, ResponseObject, DateTime.Now, ResponseType);
            }
    
            public EventResponse CreateResponse(Object ResponseSource, Object ResponseObject)
            {
                return this.CreateResponse(ResponseSource, ResponseObject, EventResponseType.Success);
            }
    
            public EventResponse CreateResponse(Object ResponseSource, String ResponseMessage)
            {
                return this.CreateResponse(ResponseSource, null, DateTime.Now, ResponseMessage, EventResponseType.Success);
            }
    
            public EventResponse CreateResponse(String ResponseMessage)
            {
                return this.CreateResponse(null, ResponseMessage);
            }
    
            public EventResponse CreateResponse(Object ResponseSource)
            {
                return this.CreateResponse(ResponseSource, String.Empty);
            }
    
            public Event Forward(Object ForwardFrom)
            {
                Event ForwardedEvent = new Event(ForwardFrom, this.EventMessage, this.EventTime);
    
                lock (this._ForwardedEvents)
                    this._ForwardedEvents.Add(ForwardedEvent);
    
                return ForwardedEvent;
            }
            #endregion
    
            #region Event Triggers
            protected void TriggerResponseFailure(EventResponse Response)
            {
                if (this.OnResponseFailure != null)
                    this.OnResponseFailure(new Event(Response, "A failure was encountered while executing this event."));
                return;
            }
            #endregion
        }
    
        public class EventResponse : IDisposable
        {
            #region Fields
            protected Event _SourceEvent = null;
    
            public Event SourceEvent
            {
                get
                {
                    return this._SourceEvent;
                }
            }
    
            public Object ResponseSource = null;
    
            public Type ResponseSourceType
            {
                get
                {
                    return this.ResponseSource.GetType();
                }
            }
    
            public Object ResponseObject = null;
    
            public Type ResponseObjectType
            {
                get
                {
                    return this.ResponseObject.GetType();
                }
            }
    
            public DateTime ResponseTime = DateTime.Now;
    
            public String ResponseMessage = String.Empty;
    
            protected StackTrace _ResponseStackTrace = null;
    
            public StackTrace ResponseStackTrace
            {
                get
                {
                    return this._ResponseStackTrace;
                }
            }
    
            public EventResponseType ResponseType = EventResponseType.Success;
            #endregion
    
            #region Constructors
            public EventResponse(Event SourceEvent)
            {
                this._SourceEvent = SourceEvent;
    
                this._ResponseStackTrace = new StackTrace();
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject, DateTime ResponseTime, String ResponseMessage, EventResponseType ResponseType)
                : this(SourceEvent)
            {
                this.ResponseSource = ResponseSource;
                this.ResponseObject = ResponseObject;
                this.ResponseTime = ResponseTime;
                this.ResponseMessage = ResponseMessage;
                this.ResponseType = ResponseType;
    
                return;
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject, DateTime ResponseTime, EventResponseType ResponseType)
                : this(SourceEvent,ResponseSource,ResponseObject,ResponseTime,String.Empty,ResponseType)
            {
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject, DateTime ResponseTime)
                : this(SourceEvent, ResponseSource, ResponseObject, ResponseTime, EventResponseType.Success)
            {
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject, EventResponseType ResponseType)
                : this(SourceEvent, ResponseSource, ResponseObject, DateTime.Now, ResponseType)
            {
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject)
                : this(SourceEvent, ResponseSource, ResponseObject, EventResponseType.Success)
            {
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, EventResponseType ResponseType)
                : this(SourceEvent, ResponseSource, null, DateTime.Now, String.Empty, ResponseType)
            {
    
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, String ResponseMessage)
                : this(SourceEvent, ResponseSource, null, DateTime.Now, ResponseMessage, EventResponseType.Success)
            {
    
            }
    
            public EventResponse(Event SourceEvent, String ResponseMessage)
                : this( SourceEvent, null, ResponseMessage )
            {
            }
            #endregion
    
            #region Supporting Methods
            public void FinalizeResponse()
            {
                this.SourceEvent.AddResponse(this);
                return;
            }
            #endregion
    
            #region Overrides
            public void Dispose()
            {
                if (this.SourceEvent == null)
                    return;
                else if (this.SourceEvent.EventResponses.Contains(this))
                    return;
                else
                {
                    EventResponse NewResponse = new EventResponse(this.SourceEvent, this.ResponseSource, this.ResponseObject, this.ResponseTime, this.ResponseMessage, this.ResponseType);
                    NewResponse.FinalizeResponse();
                    return;
                }
            }
            #endregion
        }
    }
