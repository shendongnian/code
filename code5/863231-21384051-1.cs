    [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public static SearchResults GetHighlightResults(String docID, String query,
                          String pageNumber, String resultsPerPage)
            {
                SearchResults results = null;
                try
                {
                     results = new SearchResults();
                }
                catch (Exception ex)
                {
                    // Log the exception.
                    //ArchiveViewer.Logic.ExceptionUtility.LogException(ex, "GetSearchResults in Viewer.aspx.cs");
                }
                return results;
            }
