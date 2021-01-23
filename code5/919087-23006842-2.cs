    namespace Ministry.Ministryweb
    {
        /// <summary>
        /// Elements for the site.
        /// </summary>
        public class Ministryweb
        {
            private static IContainer container;
    
            #region | Construction |
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Ministryweb" /> class.
            /// </summary>
            /// <param name="umbracoHelper">The umbraco helper instance.</param>
            public Ministryweb(UmbracoHelper umbracoHelper)
            {
                Content = new MinistrywebPublishedContentRepository(umbracoHelper);
            }
    
            #endregion
    
            public MinistrywebPublishedContentRepository Content { get; private set; }
        }
    }
