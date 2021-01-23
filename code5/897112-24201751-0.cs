    public class CollectionViewSourceCustom : CollectionViewSource
    {
		public CollectionViewSourceCustom()
			: base()
		{
			((ISupportInitialize)this).BeginInit();
			this.CollectionViewType = typeof(CustomGroupListCollectionView);
			((ISupportInitialize)this).EndInit();
		}
    }
