    /// Adds the attributes of the <see cref="T:System.Web.UI.WebControls.Button"/> control to the output stream for rendering on the client.
    /// </summary>
    /// <param name="writer">An <see cref="T:System.Web.UI.HtmlTextWriter"/> that contains the output stream to render on the client. </param>
    protected override void AddAttributesToRender(HtmlTextWriter writer)
    {
        bool useSubmitBehavior = this.UseSubmitBehavior;
        if (this.Page != null)
            this.Page.VerifyRenderingInServerForm((Control)this);
        if (useSubmitBehavior)
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
        else
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
        PostBackOptions postBackOptions = this.GetPostBackOptions();
        string uniqueId = this.UniqueID;
        if (uniqueId != null && (postBackOptions == null || postBackOptions.TargetControl == this))
            writer.AddAttribute(HtmlTextWriterAttribute.Name, uniqueId);
        writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
        bool isEnabled = this.IsEnabled;
        string firstScript = string.Empty;
        if (isEnabled)
        {
            firstScript = Util.EnsureEndWithSemiColon(this.OnClientClick);
            if (this.HasAttributes)
            {
                string str = this.Attributes["onclick"];
                if (str != null)
                {
                    firstScript = firstScript + Util.EnsureEndWithSemiColon(str);
                    this.Attributes.Remove("onclick");
                }
            }
            if (this.Page != null)
            {
                string backEventReference = this.Page.ClientScript.GetPostBackEventReference(postBackOptions, false);
                if (backEventReference != null)
                    firstScript = Util.MergeScript(firstScript, backEventReference);
            }
        }
        if (this.Page != null)
            this.Page.ClientScript.RegisterForEventValidation(postBackOptions);
        if (firstScript.Length > 0)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, firstScript);
            if (this.EnableLegacyRendering)
                writer.AddAttribute("language", "javascript", false);
        }
        if (this.Enabled && !isEnabled && this.SupportsDisabledAttribute)
            writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
        base.AddAttributesToRender(writer);
    }
