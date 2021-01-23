    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    class ExtensionlessViewCreationListener : IWpfTextViewCreationListener
    {
        [Import]
        internal IEditorFormatMapService FormatMapService = null;
        [Import]
        internal IContentTypeRegistryService ContentTypeRegistryService = null;
        [Import]
        internal SVsServiceProvider ServiceProvider = null;
        #region IWpfTextViewCreationListener Members
        void IWpfTextViewCreationListener.TextViewCreated(IWpfTextView textView)
        {
            DTE dte = (DTE)ServiceProvider.GetService(typeof(DTE));
            string docName = dte.Documents.Item(dte.Documents.Count).Name;
            if (docName.ToLower() == EditorConstants.DICTIONARY_FILE_NAME)
            {
                var contentType = ContentTypeRegistryService.GetContentType(EditorConstants.LANGUAGE_TYPE);
                textView.TextBuffer.ChangeContentType(contentType, null);
            }
        }
        #endregion
    }
