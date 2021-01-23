    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace ASP
    {
      public class webusercontrol_ascx : WebUserControl
      {
        private static bool __initialized;
    
        [DebuggerNonUserCode]
        public webusercontrol_ascx()
        {
          this.AppRelativeVirtualPath = "~/WebUserControl.ascx";
          if (webusercontrol_ascx.__initialized)
            return;
          webusercontrol_ascx.__initialized = true;
        }
    
        [DebuggerNonUserCode]
        private Label __BuildControlLabel1()
        {
          Label label = new Label();
          this.Label1 = label;
          label.ApplyStyleSheetSkin(this.Page);
          label.ID = "Label1";
          label.DataBinding += new EventHandler(this.__DataBindingLabel1);
          return label;
        }
    
        public void __DataBindingLabel1(object sender, EventArgs e)
        {
          Label label = (Label) sender;
          Control bindingContainer = label.BindingContainer;
          label.Text = Convert.ToString(this.Page.Title, (IFormatProvider) CultureInfo.CurrentCulture);
        }
    
        [DebuggerNonUserCode]
        private Button __BuildControlButton1()
        {
          Button button = new Button();
          this.Button1 = button;
          button.ApplyStyleSheetSkin(this.Page);
          button.ID = "Button1";
          button.Text = "Button";
          return button;
        }
    
        [DebuggerNonUserCode]
        private void __BuildControlTree(webusercontrol_ascx __ctrl)
        {
          IParserAccessor parserAccessor = (IParserAccessor) __ctrl;
          parserAccessor.AddParsedSubObject((object) new LiteralControl("\r\n<div class=\"customhtml\">\r\n    "));
          Label label = this.__BuildControlLabel1();
          parserAccessor.AddParsedSubObject((object) label);
          parserAccessor.AddParsedSubObject((object) new LiteralControl("\r\n    "));
          Button button = this.__BuildControlButton1();
          parserAccessor.AddParsedSubObject((object) button);
          parserAccessor.AddParsedSubObject((object) new LiteralControl("\r\n</div>\r\n"));
        }
    
        [DebuggerNonUserCode]
        protected override void FrameworkInitialize()
        {
          base.FrameworkInitialize();
          this.__BuildControlTree(this);
        }
      }
    }
