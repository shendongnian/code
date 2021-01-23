    public sealed partial class MainPage : Page
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("appUrl", "appKey");
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            AddToDebug("No class constraint:");
            NoClassConstraint<ToDoCategory>();
            AddToDebug("With class constraint:");
            WithClassConstraint<ToDoCategory>();
            //await SynchronizeAsync<ToDoCategory>();
        }
        private void NoClassConstraint<TEntity>() where TEntity : ISyncableBase
        {
            DumpWhereExpression<TEntity>(item => item.RemoteLastUpdated > DateTime.Now);
        }
        private void WithClassConstraint<TEntity>() where TEntity : class, ISyncableBase
        {
            DumpWhereExpression<TEntity>(item => item.RemoteLastUpdated > DateTime.Now);
        }
        public async Task SynchronizeAsync<TEntity>() where TEntity : class, ISyncableBase
        {
            try
            {
                var remoteTable = MobileService.GetTable<TEntity>();
                DateTime currentTimeStamp = DateTime.UtcNow.Date;
                //Get new entities
                var newEntities = await remoteTable.Where(item => ((ISyncableBase)item).RemoteLastUpdated > currentTimeStamp).ToListAsync();
                AddToDebug("New entities: {0}", string.Join(" - ", newEntities.Select(e => e.RemoteLastUpdated)));
            }
            catch (Exception ex)
            {
                AddToDebug("Error: {0}", ex);
            }
        }
        private void DumpWhereExpression<T>(Expression<Func<T, bool>> predicate)
        {
            AddToDebug("Predicate: {0}", predicate);
        }
        void AddToDebug(string text, params object[] args)
        {
            if (args != null && args.Length > 0) text = string.Format(text, args);
            this.txtDebug.Text = this.txtDebug.Text + text + Environment.NewLine;
        }
    }
    public interface ISyncableBase
    {
        DateTime RemoteLastUpdated { get; set; }
    }
    [DataContract]
    public class NotifyBase { }
    public class TableAttribute : Attribute { }
    public class ColumnAttribute : Attribute
    {
        public string DbType { get; set; }
        public bool IsDbGenerated { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool CanBeNull { get; set; }
    }
    [Table]
    [DataContract]
    public class ToDoCategory : NotifyBase, ISyncableBase
    {
        [IgnoreDataMember]
        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int LocalId { get; set; }
        [Column(CanBeNull = true)]
        [DataMember(Name = "id")]
        public int RemoteId { get; set; }
        [Column]
        [DataMember]
        public bool IsDeleted { get; set; }
        [Column]
        [DataMember]
        public DateTime RemoteLastUpdated { get; set; }
        [Column(CanBeNull = true)]
        [DataMember]
        public DateTime? LocalLastUpdated { get; set; }
    }
