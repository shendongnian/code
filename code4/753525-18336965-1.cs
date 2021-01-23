    [Range(0, 999999, ErrorMessage = "category_id must be a valid number")]
    public int? category_id { get; set; }
    // when we pass a good number
    MyAction?category_id=123
    validation: successful
    // when we pass an bad number
    MyAction?category_id=abc
    validation: "category_id must be a valid number"
    // BUT, when we don't pass any number at all ... 
    MyAction 
    validation: "category_id must be a valid number"
