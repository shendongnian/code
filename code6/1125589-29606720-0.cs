    public interface IPiece<TPlace> where TPlace : IPlace
    {
        TPlace Place { get; }
    
        void PlaceOn(TPlace place);
    }
    
    public class Block : IPiece<Grid>
    {
        private Grid _place;
    
        public Grid Place
        {
            get { return _place; }
        }
    
        public void PlaceOn(Grid place)
        {
            _place = place;
        }
    }
