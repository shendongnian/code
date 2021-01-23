    namespace SearchApplication
    {
        using System;
        using System.Windows.Forms;
        public partial class SearchOptionsForm : Form
        {
            /// <summary>
            /// Updates the 'searched' string with the selections made by the user.
            /// </summary>
            /// <param name="sender">The 'Apply' button.</param>
            /// <param name="e">Not used in this implementation.</param>
            private void ApplyClicked(object sender, EventArgs e)
            {
                // reset your filter after every click
                this.searched = string.Empty;
                // inspect all controls of interest
                foreach (var currentOption in this.searchOptionControls)
                {
                    // determine if user wants to use this filter 
                    if (currentOption.Checked)
                    {
                        // append to your existing search options
                        searched += currentOption.Name.Substring(prefix.Length);
                        // include the filter separator
                        searched += optionSeparator;
                    }
                }
                // note that filter order in the string doesn't match display order
                this.textBoxSearchFilters.Text = searched;
            }
        }
    }
