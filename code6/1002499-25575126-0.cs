        public string replace()
        {
            string appPath = Request.PhysicalApplicationPath;
            StreamReader sr = new StreamReader(appPath + "EmailTemplates/NewMember.txt");
            
            string template = sr.ReadToEnd();
            template = template.Replace("<%Client_Name%>",
                first_name.Text + " " + middle_initial.Text + " " + last_name.Text);
            //Add Customer data
            template = template.Replace("<%Client_First_Name%>", first_name.Text);
            template = template.Replace("<%Client_MI%>", middle_initial.Text);
            template = template.Replace("<%Client_Last_Name%>", last_name.Text);
            template = template.Replace("<%Client_DOB%>", dob.Text);
            return template;
        }
