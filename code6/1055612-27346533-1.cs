    using Reactive.EventAggregator;
    public partial class MessageControl : UserControl
    {
    	public MessageControl()
    	{
    	    InitializeComponent();
    	    LB.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = this.MessageCollection });
    	}
    	public ObservableCollection<MessageEvent> MessageCollection = new ObservableCollection<MessageEvent>();
    
    	public void Add(MessageEvent m)
    	{
    	    MessageCollection.Add(m);
    	}
    }
    public class MyEventAggregator
    {
    	public static EventAggregator MessageAggregator { get; set; }
    	public static void PostMessage(string message)
    	{
    	    MessageAggregator.Publish(new MessageEvent(message));
    	}
    }
