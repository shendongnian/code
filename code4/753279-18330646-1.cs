    else
    {
        // OK, opened the key, and the using statement will close it.
        // Now we can try reading values.
        string verif = key.GetValue("user_mdw_" + tara + "_CC") as string;
        if (verif == null)
        {
            // The value does not exist, or is not the type you expected it to be (string).
            // Now what? You need to make a decision here.
        }
        else
        {
            // OK, do something with verif.
        }
    }
