    public interface ISupportAllThoseNavigationFunctions
    {
        NavigableWindowsForm PreviousLocation { get; set; }
        void go(NavigableWindowsForm destination);
        void back();
    }
    public partial class NavigableWindowsForm : Form, ISupportAllThoseNavigationFunctions
    {
        private NavigableWindowsForm PreviousLocation { get; set; }
   
        go(NavigableWindowsForm destination)
        {
           //...
        }
        back()
        {
           go(PreviousLocation);
        }
    }
    public class FormA : NavigableWindowsForm
    {
        // todo: implement form A specifics
    }
    public class FormB : NavigableWindowsForm
    { 
        // todo: implement form B specifics
    }
