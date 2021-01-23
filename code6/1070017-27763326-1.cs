    var eventProxy = new ConditionalEventHandler<EventArgs>(TextBox1_TextChanged);
    TextBox1.TextChanged = eventProxy.EventAction;
    
    eventProxy.RaiseEvents = false;
    TextBox1.Text = "test";
    
    
    public void TextBox1_TextChanged(object sender, EventArgs e) {
       // some cool stuff;
    }
    
    internal class ConditionalEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly Action<object,TEventArgs> handler;
    
        public bool RaiseEvents {get; set;}
        
        public ConditionalEventHandler(Action<object, TEventArgs> handler) {
          this.RaiseEvents = true;
          this.handler = handler;
        }  
    
        public void EventAction(object sender, TEventArgs e) {
          if(!RaiseEvents) { return;}
          this.handler(sender, e);
        }
    }
