    public class BaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyProp
        {
            get
            {
               return mMyProp;
            }
            set
            {
               if( Equals( mMyProp, value ) ) return;
               mMyProp = value;
               OnPropertyChanged( "MyProp" );
        }
        protected virtual void OnPropertyChanged( string propertyName )
        {
            var handler = PropertyChanged;
            if( handler != null ) handler( this, new PropertyChangedEventArgs( propertyName ) );  
        }
    }
