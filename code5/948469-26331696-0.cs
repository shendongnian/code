    public class DataHub : Hub
    {
        public async Task Register(int groupNumber)
        {
            await this.Groups.Add(this.Context.ConnectionId, groupNumber.ToString());
        }
        public async Task Unregister(int groupNumber)
        {
            await this.Groups.Remove(this.Context.ConnectionId, groupNumber.ToString());
        }
    }
