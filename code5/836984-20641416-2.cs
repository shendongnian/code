    void MyCode() {
        var result = Program.CalledFromWebService();
        if (result.IsStep1Valid) {
             // do stuff with result.Step1Result
        } else {
            // if need be notify the user that step 1 is not complete yet
        }
        if (result.IsStep2Valid) {
             // do stuff with result.Step2Result
        }
        // etc.
    }
