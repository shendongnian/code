    namespace ASP {
        [System.Runtime.CompilerServices.CompilerGlobalScopeAttribute()]
        public class webform1_aspx : ParentPageClass, System.Web.SessionState.IRequiresSessionState, System.Web.IHttpHandler {
            String DoSomething() {
                return "lulz";
            }
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private global::System.Web.UI.WebControls.HyperLink @__BuildControl__control2() {
                global::System.Web.UI.WebControls.HyperLink @__ctrl;
            
                @__ctrl = new global::System.Web.UI.WebControls.HyperLink();
                @__ctrl.ApplyStyleSheetSkin(this);
            
                @__ctrl.Text = "WebControls are evil";
            }
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void @__BuildControlTree(webform1_aspx @__ctrl) {
            
                this.InitializeCulture();
            
                global::System.Web.UI.WebControls.HyperLink @__ctrl1;
            
                @__ctrl1 = this.@__BuildControl__control2();
            
                System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
                @__parser.AddParsedSubObject(@__ctrl1);
            
                @__ctrl.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(this.@__Render__control1));
            }
            
            private void @__Render__control1(System.Web.UI.HtmlTextWriter @__w, System.Web.UI.Control parameterContainer) {
            
                @__w.Write("\r\n    </head>\r\n    <body>\r\n        ");
            
            
                #line 11 "c:\users\dai\documents\visual studio 2013\Projects\WebApplication1\WebApplication1\WebForm1.aspx"
                int x = 5; 
            
                #line default
                #line hidden
            
                #line 12 "c:\users\dai\documents\visual studio 2013\Projects\WebApplication1\WebApplication1\WebForm1.aspx"
                @__w.Write( x );
            
                #line default
                #line hidden
            
                @__w.Write("\r\n        <div>\r\n            ");
            
                parameterContainer.Controls[0].RenderControl(@__w);
            
                @__w.Write("\r\n        </div>\r\n    </body>\r\n    </html>");
            }
        }
    }
