        public class RemoveAndBind<T> : BindingList<T>
        {
             protected override void RemoveItem(int index)
             {
                if (FireBeforeRemove != null)
                 FireBeforeRemove(this,new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
                base.RemoveItem(index);
             }
    
            public event EventHandler<ListChangedEventArgs> FireBeforeRemove;
        }
