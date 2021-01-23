    <pre class="prettyprint">
        public class RegisterViewModel<br/>
        {<br/>
            [Required]<br/>
            [Display(Name = "User name")]<br/>
            [RegularExpression("[a-zA-Z0-9]{2,64}", ErrorMessage = "username must contain    letters or numbers only, and be between 2 and 64 characters long ")]<br/>
            public string UserName { get; set; }<br/>
    <br/>
    }<br/>
    </pre>
