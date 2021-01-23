    public class City : Entity
    {
        public int Population { get; set; }
        [Required(ErrorMessage = "Please name your city")]
        public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }
    }
