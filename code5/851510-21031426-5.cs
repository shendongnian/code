    abstract class Tile {
        public abstract void Activate();
    }
    
    sealed class EmptyTile : Tile {
        public virtual void Activate() {
            Debug.WriteLine("Pecked a black square");
        }
    }
    
    sealed class ImageTile : Tile {
        public ImageTile(string content) {
            _content = content;
        }
    
        public virtual void Activate() {
            Debug.WriteLine(_content);
        }
    
        private string _content;
    }
