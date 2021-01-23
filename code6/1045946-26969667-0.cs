    private static string RenderMenuRecursive(ItemMenu menu, int level, bool firstIteration)
    {
        [...]
            if (level == 3)
            {
                if (firstIteration)
                {
                    sb.AppendLine("<ul class=\"" + "nav nav-third-level background-white collapse" + "\">");
                    firstIteration++;
                }
                sb.AppendLine("<li><a href=\"#\">" + menu.name + "</a>");
            }
        [...]
        var firstIteration = true;
        foreach (ItemMenu subMenu in menu.subMenuItems)
        {
            sb.AppendLine(RenderMenuRecursive(subMenu, level, firstIteration));
            firstIteration = false;
        }
        return sb.ToString();
    }
