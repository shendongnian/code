    List<string>project = new List<string>();
    string[] projects = { "hey","yo","app","xamarin","c","xaml" };
    
    foreach(string str in projects)
    {
       project.Add(str);
    }
    for (int i = 0; i < projects.Length; i++)
    {
      // Inflate the tile
      var tile = LayoutInflater.Inflate (Resource.Layout.Tile, null);
      // Set its attributes
      tile.FindViewById<TextView> (Resource.Id.projectName).Text = currentProject;
      // Add the tile
      projectScrollView.AddView (tile);
    }   
   
    // you can get items from your list by using  project.Count, your List<string> instead of projects.Length your array and take information from your list and output your tiles that way
