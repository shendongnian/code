	// Domain model parent object
    public class WidgetConfig 
    {
        public WidgetConfig(long id, int stateId, long? widgetId)
        {
            Id = id;
            StateId = stateId;
            WidgetId = widgetId;
        }
        private WidgetConfig()
        {
        }
        public long Id { get; set; }
        public int StateId { get; set; }
        // Ensure this type is correct
        public long? WidgetId { get; set; } 
        public virtual Widget Widget { get; set; }
    }
	
	// Domain model object
    public class Widget
    {
        public Widget(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        private Widget()
        {
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
	
	// EF mapping
    public class WidgetConfigMap : EntityTypeConfiguration<WidgetConfig>
    {
        public WidgetConfigMap()
        {
            HasKey(x => x.Id);
            ToTable(nameof(WidgetConfig));
            Property(x => x.Id).HasColumnName(nameof(WidgetConfig.Id)).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.StateId).HasColumnName(nameof(WidgetConfig.StateId)).HasColumnOrder(1);
            Property(x => x.WidgetId).HasColumnName(nameof(WidgetConfig.WidgetId));
        }
    }	
	// Service
    public class WidgetsService : ServiceBase, IWidgetsService
    {
        private IWidgetsRepository _repository;
        public WidgetsService(IWidgetsRepository repository)
        {
            _repository = repository;
        }
        public List<WidgetConfig> ListWithDetails()
        {
            var list = _repository.ListWithDetails();
            return new WidgetConfigMapping().ConvertModelListToDtoList(list).ToList();
        }
    }	
	
	// Repository
	public class WidgetsRepository: BaseRepository<WidgetConfig, long>, IWidgetsRepository
    {
        public WidgetsRepository(Context context)
            : base(context, id => widget => widget.Id == id)
        {
        }
        public IEnumerable<WidgetConfig> ListWithDetails()
        {
            var widgets = Query
                .Include(x => x.State)
                .Include(x => x.Widget);
            return widgets;
        }
    }
