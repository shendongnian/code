     protected override void OnOK(object sender, EventArgs args)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull((object) args, "args");
      string displayName;
      string text;
      if (this.Tabs.Active == 0 || this.Tabs.Active == 2)
      {
        Item selectionItem = this.InternalLinkTreeview.GetSelectionItem();
        if (selectionItem == null)
        {
          SheerResponse.Alert("Select an item.", new string[0]);
          return;
        }
        else
        {
          displayName = selectionItem.DisplayName;
          if (selectionItem.Paths.IsMediaItem)
            text = InsertLinkForm.GetMediaUrl(selectionItem);
          else if (!selectionItem.Paths.IsContentItem)
          {
            SheerResponse.Alert("Select either a content item or a media item.", new string[0]);
            return;
          }
          else
          {
            LinkUrlOptions options = new LinkUrlOptions();
            text = LinkManager.GetDynamicUrl(selectionItem, options);
          }
        }
      }
      else
      {
        MediaItem mediaItem = (MediaItem) this.MediaTreeview.GetSelectionItem();
        if (mediaItem == null)
        {
          SheerResponse.Alert("Select a media item.", new string[0]);
          return;
        }
        else
        {
          displayName = mediaItem.DisplayName;
          text = InsertLinkForm.GetMediaUrl((Item) mediaItem);
        }
      }
      if (this.Mode == "webedit")
      {
        SheerResponse.SetDialogValue(StringUtil.EscapeJavascriptString(text));
        base.OnOK(sender, args);
      }
      else
        SheerResponse.Eval("scClose(" + StringUtil.EscapeJavascriptString(text) + "," + StringUtil.EscapeJavascriptString(displayName) + ")");
    }
