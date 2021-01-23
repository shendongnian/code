    [Serializable]
    public class FormType
    {
        private List<FormTypeVersion> _versions = new List<FormTypeVersion>();
        public virtual List<FormTypeVersion> Versions
        {
            get { return _versions; }
            set { _versions = value; }
        }
    }
