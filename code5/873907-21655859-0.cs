    public class SampleModel
    {
        [Remote("ValidateName" /*action*/, "Home" /*controller*/)]
        public string Name { get; set; }
    }
