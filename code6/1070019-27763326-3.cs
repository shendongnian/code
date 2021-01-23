       var eventProxy = new ConditionalEventHandler<EventArgs>(TextBox1_TextChanged);
        TextBox1.TextChanged = eventProxy.EventAction;
        
        eventProxy.RaiseEvents = false;
        TextBox1.Text = "test";
        
        
        public void TextBox1_TextChanged(object sender, EventArgs e) {
           // some cool stuff;
        }
        
        internal class ConditionalEventHadler<TEventArgs> where TEventArgs : EventArgs
    {
       private Action<object,TEventArgs> handler;
    
        public bool RaiseEvents {get; set;}
        
    	public ConditionalEventHadler(Action<object, TEventArgs> handler)
    	{
    		this.handler = handler;	
    	}
    
        public void EventHanlder(object sender, TEventArgs e) {
          if(!RaiseEvents) { return;}
          this.handler(sender, e);
        }
    }
