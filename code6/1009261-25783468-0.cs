        public ObservableCollection<ErgaenzungsfeldEntity> ErgaenzungsfelderEntities { get; private set; }
        
        public ErgaenzungsfelderView() {
           ErgaenzungsfelderEntities = new ObservableCollection<ErgaenzungsfeldEntity>();
           InitializeComponent();
     
           // This will be called on the GUI thread
           this.guiContext = SynchronizationContext.Current;
     
       }
    
       private readonly SynchronizationContext guiContext;
         
       public void ShowErgaenzungsfelder(List<ErgaenzungsfeldEntity> entities) {
            this.guiContext.Send(this.ShowErgaenzungsfelderOnGuiThread, entities);
       }   
       private void ShowErgaenzungsfelderOnGuiThread(object state) {
           List<ErgaenzungsfeldEntity> entities = state as List<ErgaenzungsfeldEntity>;
           ErgaenzungsfelderEntities.Clear();
           entities.ForEach(e => ErgaenzungsfelderEntities.Add(e));
       }
