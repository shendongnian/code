    private static MobileServiceClient client = new MobileServiceClient(
        "https://SERVICENAME.azure-mobile.net", "APPLICATION_KEY");
    private static IMobileServiceTable<MyType> table = client.GetTable<MyType>();
    
    private async void InsertData_Click(object sender, EventArgs args) {
        for (int month = 12; month >= 9; month--) {
            var date = new DateTime(2014, month, 1, 0, 0, 0, DateTimeKind.UTC);
            await table.InsertAsync(new MyType { date = date, myfield = month });
        }
    }
    
    private async void ReadData_Click(object sender, EventArgs args) {
        var firstDate = new DateTime(2014, 9, 15, 0, 0, 0, DateTimeKind.UTC);
        var lastDate = new DateTime(2014, 11, 15, 0, 0, 0, DateTimeKind.UTC);
        var items = await table
            .Where(t => t.date >= firstTime && t.date <= lastTime)
            .ToListAsync();
        foreach (var item in items) {
            AddLog("Read item: " + item);
        }
    }
    
    public class MyType {
        public string id { get; set; }
        public DateTime date { get; set; }
        public int myfield { get; set; }
    }
