    public class PageInstance<T> : PageInstanceBase, 
        where T : new()           
    {
        #region Private Members
    
        private T _inquiryPage;
    
        #endregion
    
        #region Properties
    
        public T InquiryPage
        {
            get
            {
                if (this._inquiryPage == null)
                {
                    this._inquiryPage = new T();
                }
    
                return this._inquiryPage;
            }
        }
    
        public void Refresh() 
        {
           this._inquiryPage = new T();
        }
    }
