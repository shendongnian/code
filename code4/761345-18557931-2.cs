    using (var client = new WebClient())
    {
     result = client.DownloadString("http://bender.holovis.com/images/getDirectoryList.php");
    }
    string[] names=result.Split('|');
    foreach(string name in names)
    {
    if(name!="|"&&name!=" ")
    {
      listbox.Items.Add(name);
    }
    }
