    public class Child : Bindable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        public bool HasTwoDegrees { get { return HasHighSchoolDegree && HasUniversityDegree; } }
        private bool hasUniversityDegree;
        public bool HasUniversityDegree
        {
            get { return this.hasUniversityDegree; }
            set
            {
                SetProperty(ref hasUniversityDegree, value);
                OnPropertyChanged("HasTwoDegrees");
            }
        }
        private bool hasHighSchoolDegree;
        public bool HasHighSchoolDegree
        {
            get { return this.hasHighSchoolDegree; }
            set
            {
                SetProperty(ref hasHighSchoolDegree, value);
                OnPropertyChanged("HasTwoDegrees");
            }
        }
    }
