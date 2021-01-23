    StringBuilder table = new StringBuilder();
    table.Append(" <table class=\"table data-table\">");
        table.Append("<tbody>");
        for (int row = 1; row < Data.GetLength(0); row++)
        {
            table.Append("<tr>");
            for (int column = 1; column < Data.GetLength(1); column++)
            {
                try
                {
                    table.Append("<td>" + Data[row, column].ToString() + "</td>");
                }
                catch
                {
                    table.Append("<td></td>");
                }
            }
            table.Append("</tr>");
        }
        table.Append("</tbody>");
        table.Append("</table>");
