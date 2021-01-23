    public class MyCustomUICollectionView : UICollectionView
    {
        private static readonly UICollectionViewLayout _layout;
    
        static MyCustomUICollectionView()
        {
            // Just an example
            _layout = new UICollectionViewFlowLayout();
        }
    
        public MyCustomUICollectionView(CGRect frame) : base(frame, _layout)
        {
        }
    }
