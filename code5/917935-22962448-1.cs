    from model in Models
    let matches = CountMatches(model, value)
    where matches > 0
    select new ModelMatches
    {
        Matches = matches,
        Model = model
    }
    private int CountMatches(Model model, string value)
    {
        return (model.Name.Equals(value) ? 1 : 0) + (model.Description.Contains(value) ? 1 : 0);
    }
    public class ModelMatches
    {
        public Model Model { get; set; }
        public int Matches { get; set; }
    }
