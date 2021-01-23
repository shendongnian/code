        [WebMethod]
        public static string LoadUserControl(string query)
        {
            using (Page page = new Page())
            {
                UserControl userControl = (UserControl)page.LoadControl("OtherUserControl.ascx");
    
                page.Controls.Add(userControl);
                using (StringWriter writer = new StringWriter())
                {
                    page.Controls.Add(userControl);
                    HttpContext.Current.Server.Execute(page, writer, false);
                    return writer.ToString();
                }
            }
        }
