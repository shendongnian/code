    // HtmlAgilityPack.HtmlDocument
    /// <summary>
    /// Gets the HTML node with the specified 'id' attribute value.
    /// </summary>
    /// <param name="id">The attribute id to match. May not be null.</param>
    /// <returns>The HTML node with the matching id or null if not found.</returns>
    public HtmlNode GetElementbyId(string id)
    {
    	if (id == null)
    	{
    		throw new ArgumentNullException("id");
    	}
    	if (this._nodesid == null)
    	{
    		throw new Exception(HtmlDocument.HtmlExceptionUseIdAttributeFalse);
    	}
    	return this._nodesid[id.ToLower()] as HtmlNode;
    }
