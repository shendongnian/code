    private static List<string> values = new List<string>();
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in pholder.Controls)
            {
                if (ctr is TextBox)
                {
                    string value = ((TextBox)ctr).Text;
                    values.Add(value); // add values here
                    Response.Write(value);
                }
            }
        }
 
