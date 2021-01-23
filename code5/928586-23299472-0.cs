    Textbox tbRazred = new Textbox();
    List<string> classNumbers = new List<string>();
    // Add all your items, here is one of them
    classNumbers.Add("I-1");
    // Call the following based on some checker routine or Control. Maybe when the Textbox loses focus?
    bool pass = false;
    foreach (string thisClass in classNumbers)
    {
        if (thisClass == tbRazred.Text)
        {
            pass = true;
        }
    }
