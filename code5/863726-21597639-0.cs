    public class VM
    {
        M model;
        public M Model
        {
            get { return model; }
            set { model = value; }
        }
        public int ID
        {
            get { return model.ID; }
            set { model.ID = value; }
        }
        #region cTor
        public VM(M m)
        {
            this.Model = m;
        }
        #endregion
    }
