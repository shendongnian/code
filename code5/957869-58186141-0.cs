     public static readonly DependencyProperty CurrentBatchProperty =
         DependencyProperty.Register(
             "CurrentBatch",
             typeof(Batch),
             typeof({--- Must be same as encompassing class --}), // Error if not set properly.
             new PropertyMetadata(null, OnCurrentBatchPropertyChanged));
