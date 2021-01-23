    public void NestedMenuCalling(List<Categorie> WWW)
        {
            sb.Append("<ul class=\"Menu\">");
            foreach (WWW item in WWW.Fetch(null, null, null))
            {
                if (item.Active)
                {
                    //All pages that doesnt have a categorie
                    if (!item.Categorie.ID.HasValue)
                    {
                        sb.AppendFormat("<li><a href=\"page?id={1}\">{0}</a></li>", item.Name, item.ID.ToString());
                    }
                    //All pages that have a categorie
                    if (item.Categorie.ID.HasValue)
                    {
                        //Split different categories.
                        if (CAT != item.Categorie.Name)
                        {
                            CAT = item.Categorie.Name;
                            NestedMenuCalling(item.Categorie);
                        }
                    }
                }
                CAT = "";
            }
            sb.Append("</ul>");
        }
