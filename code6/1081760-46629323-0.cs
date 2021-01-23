    public string Email { get; set; }
    public string Phone { get; set; }
    [RequiredIf("Email != null")]
    [RequiredIf("Phone != null")]
    [AssertThat("AgreeToContact == true")]
    public bool? AgreeToContact { get; set; }
