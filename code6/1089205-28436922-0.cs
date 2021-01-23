    rivate void lstMods_DblClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
    	var selection = lstMods.SelectedItem;
    	var mod = selection as listViewItem;
    
    	MessageBox.Show(mod.LinkUrl);
    }
    public class listViewItem
    {
    	public string Text { get; set; }
    	public string ImagePic { get; set; }
    	public string LinkUrl { get; set; }
    	public System.Windows.Media.SolidColorBrush BackgroundColor { get; set; }
    	public listViewItem(string text, string image, System.Windows.Media.SolidColorBrush color, string modlink)
    	{
    		Text = text;
    		ImagePic = image;
    		BackgroundColor = color;
    		LinkUrl = modlink;
    	}
    }
    foreach (Mods modname in gameMods)
    {
    	if (Directory.Exists(Path.Combine(ArmA3PATH, "@" + modname.ModString)))
    	{
    		lstMods.Items.Add(new listViewItem
    				(
    					modname.ModName.ToString(),
    					Path.Combine(dir, modname.ModLink),
    					new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green),
    					modname.ModLink.ToString()
    				)
    			);
    	}
    	else
    	{
    		lstMods.Items.Add(new listViewItem
    				(
    					modname.ModName.ToString(),
    					Path.Combine(dir, modname.ModLink),
    					new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red),
    					modname.ModLink.ToString()
    				)
    		  );
    	}
    }
