    var Pages = new Page[viewer.Items.Count];
    for (int i = 0; i < Pages.Length ; i++)
	{
         var contentPrs = (ContentPresenter)viewer.ItemContainerGenerator.ContainerFromIndex(i);
         contentPrs.ApplyTemplate();
         var template = contentPrs.ContentTemplate;
         var currFrame = (Frame)template.FindName("frame", contentPrs );
         Pages[i] = (Page)currFrame.Content;
     }
    ((Pages.pgEditPlayer)Pages.First(p => p is pgEditPlayer)).txtPlayerName.Text = "";
