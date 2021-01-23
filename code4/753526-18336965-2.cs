    [Range(0, 999999, ErrorMessage = "category_id must be a valid number")]
    public string category_id { get; set; }
    // when we pass a good number
    MyAction?category_id=123
    validation: successful
    // when we pass a bad number
    MyAction?category_id=abc
    validation: "category_id must be a valid number"
    // no number, no validation. hooray!
    MyAction 
    validation: successful
