    public class AuthenticatedVisibilityProvider : SiteMapNodeVisibilityProviderBase
        {
            #region ISiteMapNodeVisibilityProvider Members
    
            /// <summary>
            /// Determines whether the node is visible.
            /// </summary>
            /// <param name="node">The node.</param>
            /// <param name="sourceMetadata">The source metadata.</param>
            /// <returns>
            /// 	<c>true</c> if the specified node is visible; otherwise, <c>false</c>.
            /// </returns>
            public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
            {
                return HttpContext.Current.Request.IsAuthenticated;
            }
    
            #endregion
        }
