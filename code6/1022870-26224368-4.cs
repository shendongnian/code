    public static HtmlString MyHtmlHelper(ConditionalRenderingViewModel model) {
        if(model.ShouldRenderJavascript) {
            return new HtmlString("<script type='text/javascript' src='customjs.js'></script>");
        } else {
            return new HtmlString("");
        }
    }
