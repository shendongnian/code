	[ParseChildren(false)]
	public class TestControl : WebControl, IPostBackEventHandler
	{
		protected override HtmlTextWriterTag TagKey
		{
			get { return HtmlTextWriterTag.A; }
		}
		protected override void OnPreRender(EventArgs e)
		{
			var pbo = new PostBackOptions(this, "update");
			this.Attributes.Add("href", string.Format("javascript:{0};", this.Page.ClientScript.GetPostBackEventReference(pbo)));
			ScriptManager.GetCurrent(this.Page).RegisterAsyncPostBackControl(this);
			base.OnPreRender(e);
		}
                // works when used in UpdatePanel.Triggers property.
                public event EventHandler SomeEvent;
		public void RaisePostBackEvent(string eventArgument)
		{
                        var h = SomeEvent;
                        if(h != null)
                           h(this, EventArgs.Empty);
			UpdatePanel p;
			Control parent = this.Parent;
			while (parent != null)
			{
				p = parent as UpdatePanel;
				if (p != null)
				{
					p.Update();
					return;
				}
				parent = parent.Parent;
			}
		}
	}
