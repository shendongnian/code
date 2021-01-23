       protected void Page_Load(object sender, EventArgs e)
        {
    
            List<string> emp = new List<string>();
            emp.Add("xxxx");
            emp.Add("yyy");
    
            foreach (string item in emp)
            {
                emp_list.InnerHtml += item + ", ";
            }
        }
