    string[] images = new string[] { "Star_00001.png", "Star_00002.png", "Star_00003.png" };
    string path = "Assets/Images/";
    if (LevelUp) {
        foreach(string file in images) {
            string thepath = Path.Combine(path,file);
            //do something with file or thepath, like
            Console.WriteLine(thepath);
        }
    }
