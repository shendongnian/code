    [Range(0, 999999, ErrorMessage = "category_id must be a valid number")]
    public int? category_id { get; set; }
    // when we pass a good number
    MyAction?category_id=123
    validation: successful
    // when we pass a bad number
    // validation ignores it. not what we want. 
    MyAction?category_id=abc
    validation: successful
