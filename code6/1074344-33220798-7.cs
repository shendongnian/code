    public enum Gender 
    {
        Male, Female
    }
    public class MyModel
    {
        public Gender Gender { get; set; }
        public static IEnumerable<SelectListItem> GetGenderValues()
        {
            return new [] 
            {
                new SelectListItem { Text = "Male", Value = "Male" };
                new SelectListItem { Text = "Female", Value = "Female" };
            };
        }
    }
