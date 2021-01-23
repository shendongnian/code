    int test = 0;
    string test1;
    if (filename.ToLower().Contains(".tif"))
    {
        test1 = null;
    }
    else if (ValidExtension(filename.ToLower()))
    {
        test = 1;
        test1 = "hello";
    }
