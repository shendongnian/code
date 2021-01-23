    public class SampleViewModel {
        [Required]
        public int Gender {get;set;}
        [RequiredIf("Gender", (int)Gender.Female)]
        public int? Income {get;set;}
    }
