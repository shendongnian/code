    public class MyEntityDisplayItem : DisplayItemBase<MyEntity>
    {
        private DisplayItemCollectionBase<ChildEntity> _ChildEntities;
        public DisplayItemCollectionBase<ChildEntity> ChildEntities
        {
           get { return _ChildEntities; }
           set
           {
               if (value == _ChildEntities)
                  return;
               _ChildEntities = value;
               RaisePropertyChanged("ChildEntities");
           }
        }
        public MyEntityDisplayItem(MyEntity myEntity)
        {
            ChildEntities = new DisplayItemCollectionBase<ChildEntity>(myEntity.ChildEntities);
            Item = myEntity;
        }
        public void AddChildEntity(ChildEntity childEntity)
        {
            ChildEntities.Add(childEntity);
            Item.ChildEntities.Add(childEntity);
        }
    }
