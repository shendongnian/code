    string s="TextBox1.Text= \"Hello 1\""; //1
        Dictionary<string, string> dictionary = //2
            new Dictionary<string, string>();
        dictionary.Add("Button", "TextBox1.Text= \"Hello 1\"");//3
        dictionary.Add("TextBox","TextBox1.Text= \"Hello 1\"");//4
    
    foreach(KeyValuePair<string,string> pair in dictionary)
    {
       if(s==pair.Value.ToString())
       {
           // some code
       }
    }
