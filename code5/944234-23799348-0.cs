        private IEnumerable<HtmlGenericControl> FindControls(ControlCollection controls, string className)
        {
            foreach (Control control in controls)
            {
                var c = control as HtmlGenericControl;
                if (c != null)
                {
                    var classAttribute = c.Attributes["class"];
                    if (classAttribute != null)
                        if (classAttribute.Equals(className))
                            yield return c;
                }
                if (control.HasControls())
                    foreach (var subControl in FindControls(control.Controls, className))
                        yield return subControl;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var a = FindControls(Page.Controls, "Mobile").ToList();
            a.ForEach(p=>p.Visible = false);
        }
