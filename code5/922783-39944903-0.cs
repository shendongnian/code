    [HubName("PubSub")]
	public class PubSubHub : Hub {
		public void Publish(string topic, object data) {
			Clients.Group(topic).onNewMsg(topic, data);
		}
		public async Task Subscribe(string topic) {
			await Groups.Add(Context.ConnectionId, topic);
			Clients.Client(Context.ConnectionId).onSubscribed(topic);
		}
		public async Task Unsubscribe(string topic) {
			await Groups.Remove(Context.ConnectionId, topic);
			Clients.Client(Context.ConnectionId).onUnsubscribed(topic);
		}
	}
