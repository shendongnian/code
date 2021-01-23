    public class MyModel
    {
        public string MyDescription {get; set;}
        public string MyShortDescription {
            get 
            {
                  return Truncate(MyDescription, 25);
            }
    }
    
    private string Truncate(string, howMany)
    {
       // Code to perform the substring here
    }
    @Html.DisplayFor(modelItem => item.MyShortDescription);
