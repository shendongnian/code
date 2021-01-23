    public class BO_InputforgettingGridWrapper
    {
        private BO_InputforgettingGrid baseobject;
        public BO_InputforgettingGridWrapper(BO_InputforgettingGrid obj)
        {
             baseobject = obj;
        }
        public string RowText 
        { 
           get
           {
               return string.Format("{0}{1}...", baseobject.Brand ...);
           }
        }
    }
