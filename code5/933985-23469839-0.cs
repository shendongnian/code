    public class PersonEditModel
    {
        public Person PersonToEdit { get; set; } //This is your entity from before
    
        public List<Country> Countries { get; set; } //Extra data for the view
    }
