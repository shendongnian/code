    var sb = new StringBuilder();
    this.GetAuditMessage(grpAccess, sb);
    var message = sb.ToString();
    private void GetAuditMessage(Control c_parent, StringBuilder sb) {
        foreach(Control c in c_parent.Controls)  {       
            Console.WriteLine(c.Name);
            if (c is System.Windows.Forms.Panel) {
                try {
                    GetAuditMessage(c, sb);
                } catch(Exception nu)  {
                    Console.WriteLine(nu.Message);
                }
            }
            else if (c is System.Windows.Forms.TextBox ||
                c is System.Windows.Forms.ComboBox)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString();
                int n = tag.IndexOf(":");
                if(n < 0) continue;
                int len = tag.Length;
                string controlName = tag.Substring(0, n);
                string oldSetting = tag.Substring(n + 1, len - (n + 1));
                if (!oldSetting.Equals(c.Text))
                {
                    sb.AppendFormat("Change {0} from '{1}' to '{2}'.",
                        controlName, oldSetting, c.Text).AppendLine();
                }
            }
        }
    }
