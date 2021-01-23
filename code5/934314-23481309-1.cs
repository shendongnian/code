    private string getctl(Control master)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Control child in master.Controls)
            {
                sb.AppendFormat("| {0} - {1}", child.ClientID.ToString(), child.GetType().ToString());
                if (child.HasControls())
                {
                    sb.Append(getctl(child));
                }
            }
            return sb.ToString();
        }
