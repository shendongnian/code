        string a, b, c;
        a = b = c = string.Empty;
        if (a == b)
        {
            //Conventional syntax.
            c = a + b;
        }
        if (a == b)
            // But really, for simple if statements curly braces are not needed.
            c = a + b;
        //Typically you will _not_ see this treatment of curly braces,
        //which is used instead in JavaScript.
        if (a == b) {
            c = a + b;
        }
