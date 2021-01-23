    	private static readonly int MouseDownEvent = EventsProperty.CreateEventKey();
    	public event ElementMouseEventHandler MouseDown
		{
			add { AddHandler(MouseDownEvent, value); }
			remove { RemoveHandler(MouseDownEvent, value); }
		}
    	public virtual void OnMouseDown(ElementMouseEventArgs args)
		{
			ElementMouseEventHandler handler = 
				FindHandler(MouseDownEvent) as ElementMouseEventHandler;
			if (handler != null)
				handler(this, args);
		}
    	internal void AddHandler(int key, Delegate value)
		{
			EventsProperty p = (EventsProperty)GetOrInsertProperty(EventsProperty.Key);
			p.AddHandler(key, value);
		}
		internal void RemoveHandler(int key, Delegate value)
		{
			EventsProperty p = (EventsProperty)GetProperty(EventsProperty.Key);
			if (p == null)
				return;
			p.RemoveHandler(key, value);
		}
		internal Delegate FindHandler(int key)
		{
			EventsProperty p = (EventsProperty)GetProperty(EventsProperty.Key);
			if (p == null)
				return null;
			return p[key];
		}
