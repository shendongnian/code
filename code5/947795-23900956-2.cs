    namespace SearchApplication
    {
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Forms;
        public partial class SearchOptionsForm : Form
        {
            // prefix you used for all your checkboxes
            private const string prefix = @"cbx";
            // store *all* checkboxes in your form
            // if you had other checkboxes in your form, 
            // you would need to think how you would want to differentiate them
            private IEnumerable<CheckBox> searchOptionControls;
            // represents all choices made by the user to customize the search type
            private string searched;
            // since your 'searched' variable is a string, 
            // you need a filter separator to be able to tell user selections apart
            private const string optionSeparator = @";";
            public SearchOptionsForm()
            {
                this.InitializeComponent();
                // initialize your collection of checkboxes
                this.searchOptionControls = this.Controls.OfType<CheckBox>();
            }
        }
    }
