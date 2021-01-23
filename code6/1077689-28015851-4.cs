    void Assert.Equals(string actual, string expected)
    {
        if ( actual == expected )
        {
            // Pass. Nothing more to do.
        }
        else
        {
            // Fail the test now.
            throw AnAssertionFailureException(...);
        }
    }
