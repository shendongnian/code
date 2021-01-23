    var validator = Validators.Class1Validator;
    var c1 = new Class1
        {
            id = 1,
            Class2 = new Class2
                {
                    id = 2,
                    Class3 = new Class3
                        {
                            id = 3,
                            Class1 = new Class1
                                {
                                    id = 0,
                                    Class2 = null
                                }
                        }
                }
        };
    var result = validator.Validate(c1);
