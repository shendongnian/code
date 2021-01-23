        private List<Note> _Notes;
        public List<Note> Notes
        {
            get
            {
                if(_Notes == null)
                     _Notes = new List<Note>();
                return _Notes;
            }
            set
            {
                _Notes = value;
            }
        }
