            var builder = new StringBuilder(
                string.Format("{0}{1}{2:dd/MM/yyyy hh:mm}- (Incident saved by: {3})",
                    txtAuditLogReadOnly.Text,
                    Environment.NewLine,
                    DateTime.Now,
                    Page.User.Identity.Name));
            var controls = from Control c in divContainer.Controls
                           select c;
            foreach (var ctl in controls)
            {
                if (ctl is TextBox)
                {
                    var txt = (TextBox)ctl;
                    if (!string.IsNullOrEmpty(txt.Text))
                    {
                        string fieldname = txt.Attributes["fieldname"];
                        builder.AppendFormat(" - with changes to {0}", fieldname);
                    }
                }
            }
            return builder.ToString();
