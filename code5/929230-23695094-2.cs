    namespace ASP {
      public class foocontrol_ascx : global::TestApplication.FooControl {
        private static bool @__initialized;
          
        public foocontrol_ascx() {
            ((global::WebApplication4.FooControl)(this)).AppRelativeVirtualPath = "~/FooControl.ascx";
            if ((global::ASP.foocontrol_ascx.@__initialized == false)) {
                global::ASP.foocontrol_ascx.@__initialized = true;
            }
        }
          
        private global::System.Web.UI.WebControls.Literal @__BuildControllitBar() {
            global::System.Web.UI.WebControls.Literal @__ctrl;
              
            @__ctrl = new global::System.Web.UI.WebControls.Literal();
            this.litBar = @__ctrl;
            @__ctrl.ID = "litBar";
            @__ctrl.Text = "Whatever";
            return @__ctrl;
        }
          
        private void @__BuildControlTree(foocontrol_ascx @__ctrl) {
            global::System.Web.UI.WebControls.Literal @__ctrl1;
            @__ctrl1 = this.@__BuildControllitBar();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
        }
          
        protected override void FrameworkInitialize() {
            base.FrameworkInitialize();
            this.@__BuildControlTree(this);
        }
      }
    }
