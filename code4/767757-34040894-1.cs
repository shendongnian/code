        [GroupRequired("Year", "Month", "Day", ErrorMessage = "Please enter your date of birth")]
        [PermittedYearRange]
        public int? Year { get; set; }
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int? Month { get; set; }
        [Range(1, 31, ErrorMessage = "Day must be between 1 and 31")]
        public int? Day { get; set; }
