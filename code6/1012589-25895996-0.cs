    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;
    
    namespace Blah
    {
        public class ExtendedDropDownList : DropDownList
        {
            private CustomValidator _cv;
            public bool Required { get; set; }
            public String FieldName { get; set; }
            public String ValidatorPlaceHolder { get; set; }
    
            protected override void OnInit(EventArgs e)
            {
                _cv = new CustomValidator()
                {
                    ControlToValidate = ID,
                    EnableClientScript = false,
                    ValidationGroup = ValidationGroup,
                    Display = ValidatorDisplay.None,
                    ValidateEmptyText = true
                };
                _cv.ServerValidate += new ServerValidateEventHandler(_cv_ServerValidate);
                if (Parent.FindControl(ValidatorPlaceHolder) != null)
                    Parent.FindControl(ValidatorPlaceHolder).Controls.Add(_cv);
                else
                    throw new Exception("Cannot find asp:PlaceHolder inside parent with ID '" + ValidatorPlaceHolder + "'");
                base.OnInit(e);
            }
    
            private void _cv_ServerValidate(object source, ServerValidateEventArgs args)
            {
                if (Required && String.IsNullOrWhiteSpace(args.Value))
                {
                    args.IsValid = false;
                    _cv.ErrorMessage = "The field <strong>" + FieldName + "</strong> is required.";
                    return;
                }            
            }
    
        }
    }
