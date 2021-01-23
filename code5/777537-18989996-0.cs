    public class Battlefield
    {
        private readonly IList<IBattleElement> _all = new List<IBattleElement>();
        private IReadOnlyList<IActor> _actors;
        private bool _isDirty;
        /// <summary>
        ///     Gets a list of all elements.
        /// </summary>
        public IReadOnlyList<IBattleElement> All
        {
            get { return _all; }
        }
        /// <summary>
        ///     Gets a filtered list of elements that are <c>IActor</c>.
        /// </summary>
        public IReadOnlyList<IActor> Actors
        {
            get
            {
                if( _isDirty || _actors == null )
                {
                    _actors = All.OfType<IActor>().ToList();
                }
                return _actors;
            }
        }
        /// <summary>
        ///     The one and only way to add new elements. This could be made thread-safe if needed.
        /// </summary>
        /// <param name="element"></param>
        public void AddElement( IBattleElement element )
        {
            _all.Add( element );
            _isDirty = true;
        }
    }
