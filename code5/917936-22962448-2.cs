    from model in dc.Models
    where model.Name.Equals(value) || model.Description.Contains(value)
    select new ModelMatches
    {
        Matches = (model.Name.Equals(value) ? 1 : 0) + (model.Description.Contains(value) ? 1 : 0),
        Model = model
    };
    public class ModelMatches
    {
        public Model Model { get; set; }
        public int Matches { get; set; }
    }
