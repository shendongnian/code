    using System;
    using System.Web.UI.WebControls;
    
    public partial class PgValidationDemo : System.Web.UI.Page
    {
        // bind page init
        // in the page constructor
        public PgValidationDemo()
        {
            this.Init += PgValidationDemo_Init;
        }
    
        // Bind our submit button click event
        private void PgValidationDemo_Init(object sender, EventArgs e)
        {
            cmdSubmit.Click += cmdSubmit_Click;
        }
    
        // handle the submit button
        // click event
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            // Tell the form to validate
            // fields in validation group
            // 'ValidationDemo'
            String vGroup = "ValidationDemo";
            vSummary.ValidationGroup = vGroup;
            Page.Validate(vGroup);
    
            // Call our fantastic convenience method
            // to check if a textbox has a value in it
            this.addRequiredFieldValidator(txtFirstName, vGroup, "FirstName is Required.");
    
            // If Page.IsValid
            // redirect to the 'thanks page'
            // if it isnt valid we don't need to
            // provide additional code because
            // the error messages will show in the
            // validation summary
            if (Page.IsValid)
            {
                //Redirect to Thanks for filling out survey
            }
        }
    
        // convenience method to add required
        // text validators to the form collection
        private void addRequiredFieldValidator(TextBox txt, String validationGroup, String errorMessage)
        {
            Page.Validators.Add(new CustomValidator()
            {
                IsValid = !String.IsNullOrWhiteSpace(txt.Text),
                ErrorMessage = errorMessage,
                ValidationGroup = validationGroup
            });
        }
    }
