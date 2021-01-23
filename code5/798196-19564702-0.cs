    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public void RecreateCollection( IList<T> newList )
        {
            // nothing changed => do nothing
            if( this.IsEqualToCollection( newList ) ) return;
            // handle deleted items
            IList<T> deletedItems = this.GetDeletedItems( newList );
            if( deletedItems.Count > 0 )
            {
                foreach( T deletedItem in deletedItems )
                {
                    this.Remove( deletedItem );
                }
            }
            
            // handle added items
            IList<T> addedItems = this.GetAddedItems( newList );           
            if( addedItems.Count > 0 )
            {
                foreach( T addedItem in addedItems )
                {
                    this.Add( addedItem );
                }
            }
            // equals now? => return
            if( this.IsEqualToCollection( newList ) ) return;
            // resort entries
            for( int index = 0; index < newList.Count; index++ )
            {
                T item = newList[index];
                int indexOfItem = this.IndexOf( item );
                if( indexOfItem != index ) this.Move( indexOfItem, index );
            }
        }
        private IList<T> GetAddedItems( IEnumerable<T> newList )
        {
            IList<T> addedItems = new List<T>();
            foreach( T item in newList )
            {
                if( !this.ContainsItem( item ) ) addedItems.Add( item );
            }
            return addedItems;
        }
        private IList<T> GetDeletedItems( IEnumerable<T> newList )
        {
            IList<T> deletedItems = new List<T>();
            foreach( var item in this.Items )
            {
                if( !newList.Contains( item ) ) deletedItems.Add( item );
            }
            return deletedItems;
        }
        private bool IsEqualToCollection( IList<T> newList )
        {   
            // diffent number of items => collection differs
            if( this.Items.Count != newList.Count ) return false;
            for( int i = 0; i < this.Items.Count; i++ )
            {
                if( !this.Items[i].Equals( newList[i] ) ) return false;
            }
            return true;
        }
        private bool ContainsItem( object value )
        {
            foreach( var item in this.Items )
            {
                if( value.Equals( item ) ) return true;
            }
            return false;
        }
    }
