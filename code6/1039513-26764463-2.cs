    public class Action {
        //This two can (must) be overriden
        public const string _HoverCursor = "Textures/cursors/select";
        public virtual string HoverCursor { get { return _HoverCursor; } }
        //This is the get texture by string
        private static Texture2D cursorTex = null;
        public virtual Texture2D cursor
        {
            get
            {
                return ResourceManager.loadTexture(ref cursorTex, HoverCursor);
            }
        }
    }
    public class Attack {
        //This two can (must) be overriden
        public const string _HoverCursor = "Textures/cursors/attack";
        public virtual string HoverCursor { get { return _HoverCursor; } }
        //This is the get texture by string
        private static Texture2D cursorTex = null;
        public override Texture2D cursor
        {
            get
            {
                return ResourceManager.loadTexture(ref cursorTex, HoverCursor);
            }
        }
    }
