    public enum Gender 
    {
        Male, Female
    }
    public class MyModel
    {
        public Gender Gender { get; set; }
        public static IEnumerable<SelectListItem> GetGenderSelectItems()
        {
            yield return new SelectListItem { Text = "Male", Value = "Male" };
            yield return new SelectListItem { Text = "Female", Value = "Female" };
        }
    }
