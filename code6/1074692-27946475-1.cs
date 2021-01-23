    public WpfButton UIItemCell
    {
        get
        {
            WfpButton target = new WpfButton(parentElement);
            target.SearchProperties["name"] = "secondButton";
            return target;
        }
    }
