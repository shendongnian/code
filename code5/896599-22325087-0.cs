       List<string> lst = new List<string>();
            if(Session["List"] != null)
                lst = (List<string>)Session["List"];
            if (Session["List"] == null)
            {
                lst.Add(txtAdd.Text);
            }
            else
            {
                lst.Insert(i, txtAdd.Text);
                i++;
            }
            Session["List"] = lst;
