void ContentService_Saving(IContentService sender, SaveEventArgs<IContent> e)
{                      
     ShowErrorBubble(e, "Error saving item", "Error:duplicate records exists");
}
private static void ShowErrorBubble(SaveEventArgs e, string title, string text)
{           
    try
    {
        e.Messages.Add(new Umbraco.Core.Events.EventMessage(title, text, Umbraco.Core.Events.EventMessageType.Warning));
        e.Cancel = true;
    }
    catch (Exception ex)
    {
            //do nothing at the moment, forums suggest we cannot send an error message
    }
}
