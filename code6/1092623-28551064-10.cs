    namespace SampleCase3
    {
        public interface ISurface { }
        public class GDISurface : ISurface { }
        public class Plane<T> where T : ISurface
        {
            public event EventHandler<DrawingErrorEventArgs> DrawingError;
            public class DrawingErrorEventArgs : EventArgs { T stuff; }
        }
        public class TestControl : UserControl
        {
            private Plane<GDISurface> _Plane = new Plane<GDISurface>(); // requires initialization for my own testing
            public TestControl()
            {
            }
            // i am adding this map *only* so that the removal of an event handler can be done properly
            private Dictionary<EventHandler, EventHandler<Plane<GDISurface>.DrawingErrorEventArgs>> _cleanupMap = new Dictionary<EventHandler, EventHandler<Plane<GDISurface>.DrawingErrorEventArgs>>();
        
            public event EventHandler DrawingError
            {
                add
                {
                    var nonGenericHandler = value;
                    var genericHandler = (EventHandler<Plane<GDISurface>.DrawingErrorEventArgs>)delegate(object sender, Plane<GDISurface>.DrawingErrorEventArgs e)
                    {
                        nonGenericHandler(sender, e);
                    };
                    _Plane.DrawingError += genericHandler;
                    _cleanupMap[nonGenericHandler] = genericHandler;
                }
                remove
                {
                    var nonGenericHandler = value;
                    var genericHandler = default(EventHandler<Plane<GDISurface>.DrawingErrorEventArgs>);
                    if (_cleanupMap.TryGetValue(nonGenericHandler, out genericHandler))
                    {
                        _Plane.DrawingError -= genericHandler;
                        _cleanupMap.Remove(nonGenericHandler);
                    }
                }
            }
        }
    }
