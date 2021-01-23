    public static class MVCHelpers
    {
        public static MvcHtmlString CompleteValue(this HtmlHelper htmlHelper, int value)
        {
            //create the html helper
            var builder = new TagBuilder("text");
            //Check value
            switch (value)
            {
                case 0:
                    builder.SetInnerText("Submitted");
                    break;
                case 1:
                    builder.SetInnerText("Verified - Incomplete");
                    break;
                case 2:
                    builder.setInnerText("Verified - Complete");
                    break;
                default:
                    builder.setInnerText("Submitted");
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
