    public class ClothingViewModel : ViewModelBase
    {
        private readonly PopulateColors colors = new PopulateColors();
        public PopulateColors Colors
        {
            get { return this.colors; }
        }
        
        ...
    }
