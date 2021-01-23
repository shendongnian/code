    public class Sprite
    {
        // ...
   
        public SpriteMemento Memento
        {
            get { return new SpriteMemento { X = _x, Y = _y }; }
        }
        public void Restore(SpriteMemento memento)
        {
            if (memento == null)
                return; 
            _x = memento.X;
            _y = memento.Y;
        }
    }
