    public void DataSource(object source, object select, string Value = "UId", string Text = "Text")
    {
        ddlThis.DataSource = source;
        ddlThis.DataTextField = Text;
        ddlThis.DataValueField = Value;
        ddlThis.DataBind();
        ddlThisHidden.DataSource = source;
        ddlThisHidden.DataTextField = Text;
        ddlThisHidden.DataValueField = Value;
        ddlThisHidden.DataBind();
        if (select != null)
        {
            ddlOther.DataSource = select;
            ddlOther.DataTextField = Text;
            ddlOther.DataValueField = Value;
            ddlOther.DataBind();
            if (select is IEnumerable) //check if the object is a list of objects
                foreach (var item in (IEnumerable)ddlOther.DataSource)
                    ddlThis.Items.Remove(item);
            else //try to remove the single object
                ddlThis.Items.Remove(select)
        }
    }
