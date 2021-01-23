    int a = 4;
    var aIsGreaterThanThree = (a > 3)
    if (aIsGreaterThanThree)
    {
       SetLabelsToHello();
    }
    else 
    {
       SetLabelsToHi();
    }
    void SetLablesToHello()
    {  
       Label1.Text = "Hello";
       Label2.Text = "How are you?";
    }
    void SetLabelsToHi() 
    {
       Label1.Text = "Hi";
       Label2.Text = "How do you do";
    }
