    using System.Web.UI;
    public abstract class BasePage : Page
    {
        public void FindAllControls()
        {
            var currentClassName = this.GetType().BaseType.Name;
            // Do stuff.
        }
    }
