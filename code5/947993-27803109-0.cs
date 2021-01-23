        /// <summary>
        /// Gets a SharePointContext instance associated with the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>The SharePointContext instance. Returns <c>null</c> if not found and a new instance can't be created.</returns>
        public SharePointContext GetSharePointContext(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            // Commented out to allow it to work without the SPHostUrl being passed around
            //Uri spHostUrl = SharePointContext.GetSPHostUrl(httpContext.Request);
            //if (spHostUrl == null)
            //{
            //    return null;
            //}
            SharePointContext spContext = LoadSharePointContext(httpContext);
            if (spContext == null || !ValidateSharePointContext(spContext, httpContext))
            {
                spContext = CreateSharePointContext(httpContext.Request);
                if (spContext != null)
                {
                    SaveSharePointContext(spContext, httpContext);
                }
            }
            return spContext;
        }
