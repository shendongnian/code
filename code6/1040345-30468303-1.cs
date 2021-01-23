    sb.Append("<ul class=\"Menu\">");
    foreach (Categories category in Categories.Fetch(null, null, null))
    {
        if (category.Active)
        {
			sb.AppendFormat("<li><a href=\"page?id={1}\">{0}</a>", category.Name, category.ID.ToString());
			var pages = WWW.Fetch(p => p.Categorie.ID.Equals(category.ID));
			if(pages.Any()) {
				sb.Append("<ul>");
				foreach(WWW page in pages) {
					sb.AppendFormat("<li><a href=\"page?id={1}\">{0}</a></li>", page.Name, page.ID.ToString());
				}
				sb.Append("</ul>");
			}
			sb.Append("</li>");
        }
    }
    sb.Append("</ul>");
