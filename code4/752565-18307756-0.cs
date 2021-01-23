    public class TVOffCommand : Command    
    {
        ITV tv;
    
        public TVOffCommand (ITV aTV)
        {
            this.tv= aTv;
        }
    
        #region Command Members
    
        public object Execute()
        {
            return tv.Off();
        }
    
        #endregion
    }
