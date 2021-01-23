            if (IsInEditingMode)
            {
                strMenuText.Append(RenderLink(
                    linkitem,
                    x => x.NavigationItem.Url
                    isEditable: false,
                    contents: linkitem.NavigationTitle));
            }
            else
            {
                strMenuText.Append(RenderLink(
                    linkitem,
                    x => x.NavigationItem.Url.StringToLink(),
                    isEditable: false,
                    contents: linkitem.NavigationTitle));
            }
