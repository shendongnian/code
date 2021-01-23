    void Func1()
    {
        var userNotification = new { Text = "Here is some text!", Url = "http://www.google.com/#q=notifications" };
        Func2(userNotification);
    }
    void Func2(dynamic userNotification)
    {
        string value = notification.Text;
    }
