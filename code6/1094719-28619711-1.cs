    public partial class classname
    {
        [NotMapped]
        public string CleanName
        {
            get { return Name; }
            set
            {
                var cleanName = clsStringManip.CleanText(value, true);
                if (cleanName != Name)
                    Name = cleanName;
            }
        }
    }
