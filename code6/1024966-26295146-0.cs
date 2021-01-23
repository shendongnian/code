    //INPC implementation removed in this sample
    public class PersonViewModel
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }
    var person = new PersonViewModel {
        FirstName = "John",
        LastName = "Doe",
    };
    var first = new Label ();
    first.SetBinding (Label.TextProperty, "FirstName");
    var label = new Label ();
    label.SetBinding (Label.TextProperty, "LastName");
    var personView = new StackLayout {
        Orientation = StackOrientation.Horizontal,
        Children = {
            first,
            last
        }
    };
    personView.BindingContext = person;
