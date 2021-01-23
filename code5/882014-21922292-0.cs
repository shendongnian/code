    foreach (var id in ids)
    {
        // How to add id to result where result becomes Mvc.Areas.MyArea.Index(id)?
        // *** ANSWER
        result.GetRouteValueDictionary()["id"] = id;
        // *** ANSWER
        sb.Append(helper.ActionLink(id, result);
        sb.Append("<br/>");
    }
