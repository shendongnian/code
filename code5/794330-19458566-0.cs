    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Reflection;
    
    namespace EventHandling
    {
        public delegate EventResponse EventHandler(Event Event);
    
        public class Event
        {
            #region Events
            public event EventHandler OnResponseFailure = null;
            #endregion
    
            #region Fields
            public Object EventObject = null;
    
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
    
            public List<EventResponse> FailedResponses
            {
                get
                {
                    List<EventResponse> FailedResponses = new List<EventResponse>();
    
                    foreach (EventResponse Response in this.EventResponses)
                        if (Response.ResponseType == EventResponse.EventResponseType.Failure)
                            FailedResponses.Add(Response);
                    return FailedResponses;
                }
            }
            #endregion
    
            #region Constructors
            public Event()
            {
                this._EventResponses = new List<EventResponse>();
                this._EventStackTrace = new StackTrace();
            }
    
            public Event(Object EventObject, DateTime EventTime, String EventMessage)
                : this()
            {
                this.EventObject = EventObject;
                this.EventTime = EventTime;
                this.EventMessage = EventMessage;
    
                return;
            }
    
            public Event(Object EventObject, String EventMessage)
                : this( EventObject, DateTime.Now, EventMessage )
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
    
                if (Response.ResponseType == EventResponse.EventResponseType.Failure)
                    this.TriggerResponseFailure(Response);
    
                return;
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
    
        public class EventResponse
        {
            #region Enumerations
            public enum EventResponseType
            {
                Success, Failure
            }
            #endregion
    
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
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject, DateTime ResponseTime)
                : this(SourceEvent, ResponseSource, ResponseObject, ResponseTime, String.Empty, EventResponseType.Success)
            {
            }
    
            public EventResponse(Event SourceEvent, Object ResponseSource, Object ResponseObject, EventResponseType ResponseType)
                : this(SourceEvent, ResponseSource, ResponseObject, DateTime.Now, String.Empty, ResponseType)
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
            #endregion
    
            #region Supporting Methods
            public void FinalizeResponse()
            {
                this.SourceEvent.AddResponse(this);
                return;
            }
            #endregion
        }
    }
