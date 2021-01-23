    BindingSource bs = new BindingSource();
    List<string> names1 = new List();
    bs.DataSource = names1;
    comboBox.DataSource = bs;
       using (var testy = new WebClient())
        {
            test = testy.DownloadString("http://server.foo.com/images/getDirectoryList.php?dir=test_folder");
            names1.AddRange(test.Split('|'));
            bs.ResetBindings(false);
        }
