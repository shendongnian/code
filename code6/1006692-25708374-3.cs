    string text = Encoding.UTF8.GetString(File.ReadAllBytes(place + "/" + temname + ".html"));
    HTMLTEXT.Text = text.Split(new string[] { "//this arena" }, StringSplitOptions.None)[1].Split(new string[] { "//end Arena" }, StringSplitOptions.None)[0];
    //after your edit
    
    string editedText = text.Split(new string[] { "//this arena" }, StringSplitOptions.None)[0] + "//this arena" + HTMLTEXT.Text + "//end Arena" +  text.Split(new string[] { "//this arena" }, StringSplitOptions.None)[1].Split(new string[] { "//end Arena" }, StringSplitOptions.None)[1];
            
    File.WriteAllText("Path", editedText, Encoding.UTF8);
