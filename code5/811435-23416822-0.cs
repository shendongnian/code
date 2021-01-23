                text = "";
                if (link == null)
                    return false;
                if (!string.IsNullOrEmpty(link.Text))
                {
                    text = link.Text;
                    return true;
                }
                switch (link.LinkType)
                {
                    case "internal":
                        if (link.TargetItem == null)
                            return false;
                        text = link["Text Field Name"];
                        break;
                    case "external":
                    case "mailto":
                    case "anchor":
                    case "javascript":
                        text = link.Text;
                        break;
                    case "media":
                        if (link.TargetItem == null)
                            return false;
                        Sitecore.Data.Items.MediaItem media = new Sitecore.Data.Items.MediaItem(link.TargetItem);
                        text = media.Name;
                        break;
                    case "":
                        break;
                    default:
                        return "";
                }
                return  link["Text Field Name"];
            }
