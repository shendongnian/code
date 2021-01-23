      private SynchronizationContext _sync;
      public Form1() {
         InitializeComponent();
         _sync = SynchronizationContext.Current;
      }
      private void FilterTextChanged(object sender, EventArgs e) {
         if (filterTimer != null) {
            filterTimer.Stop();
            filterTimer.Elapsed -= delegate { ProcessFilterTextChanged(sender); };
         }
         filterTimer = new System.Timers.Timer(1000) {
            AutoReset = false
         };
         filterTimer.Elapsed += delegate { ProcessFilterTextChanged(sender); };
         filterTimer.Start();
      }
      private void ProcessFilterTextChanged(object source) {
         _sync.Post((state) => {
            collectionView.Filter = CollectionFilter;
            collectionView.Refresh();
         }, null);
      }
      private bool CollectionFilter(object item) {
         var filterStrings = tbFilter.Text.ToLower();
         //filtering happens here
      }
