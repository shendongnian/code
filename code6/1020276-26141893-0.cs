    using System.ComponentModel.DataAnnotations;
    public class LoginModel {
        [DataType(DataType.Text, ErrorMessage="Invalid entry."), 
        MaxLength(100, ErrorMessage="Username must be 100 characters or less."),
        Required(AllowEmptyStrings=false, ErrorMessage="UserName is required.")]
        public string UserName { get; set; }
        ...
    }
