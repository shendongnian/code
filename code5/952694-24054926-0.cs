    public int SetLabels(string label1text, string label2text)
    {
       try
       {
            Label1.Text = label1text;
            Label2.Text = label2text;
    
            return 0;
       }
       catch
       {
            return 1;
       }
    }
    var result = a > 3 ? SetLabels("Hello", "How are you?") : SetLabels("Hi!", "How do you do");
