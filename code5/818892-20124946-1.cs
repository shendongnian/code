    public class ViewStateCompressor : PageStatePersister
    {
        private const string ViewStateKey   = "__VSTATE";
        public ViewStateCompressor(Page page) : base(page)
        {
        }
        private LosFormatter stateFormatter;
        protected new LosFormatter StateFormatter
        {
            get { return this.stateFormatter ?? (this.stateFormatter = new LosFormatter()); }
        }
        public override void Save()
        {
            using (StringWriter writer = new StringWriter(System.Globalization.CultureInfo.InvariantCulture))
            {
            	// Put viewstate data on writer
                StateFormatter.Serialize(writer, new Pair(base.ViewState, base.ControlState));
				// Handle your viewstate data
                // byte[] bytes = Convert.FromBase64String(writer.ToString());
				// Here I create another hidden field named "__VSTATE"
                ScriptManager.RegisterHiddenField(Page, ViewStateKey, Convert.ToBase64String(output.ToArray()));
            }
        }
        public override void Load()
        {
            byte[] bytes = Convert.FromBase64String(base.Page.Request.Form[ViewStateKey]);
            using (MemoryStream input = new MemoryStream())
            {
                input.Write(bytes, 0, bytes.Length);
                input.Position = 0;
                
                // Handle your viewstate data
                Pair p = ((Pair)(StateFormatter.Deserialize(Convert.ToBase64String(output.ToArray()))));
                base.ViewState = p.First;
                base.ControlState = p.Second;
            }
        }
    }
