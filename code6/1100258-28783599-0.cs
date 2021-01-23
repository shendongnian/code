    public class ModelSummary : Model
    {
        private IEnumerable<Model> models;
        public ModelSummary(IEnumerable<Model> models)
        {
            this.models = models;
            foreach (Model model in models)
            {
                model.PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
            }
        }
        public override int Value1
        {
            get
            {
                return models.Sum(m => m.Value1);
            }
        }
    }
