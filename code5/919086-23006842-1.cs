    /// <summary>
    /// An abstract base class for Ministryweb views.
    /// </summary>
    public abstract class MinistrywebViewPage : UmbracoTemplatePage
    {
        private Ministryweb ministryweb;
    
        /// <summary>
        /// Gets the model in a dynamic form.
        /// </summary>
        public dynamic DynamicModel { get { return CurrentPage; } }
    
        /// <summary>
        /// Entry point for helper functions defined at root site level.
        /// </summary>
        /// <value>
        /// The ministryweb helper object.
        /// </value>
        public Ministryweb Ministryweb
        {
            get
            {
                ministryweb = ministryweb ?? new Ministryweb(Umbraco);
                return ministryweb;
            }
        }
    }
