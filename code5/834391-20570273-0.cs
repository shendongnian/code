    string[] catvals = new string[catListView.Items.Count];
                for (int i =0; i< catListView.Items.Count; i++)
                {
                    Label catLabel = (Label)catListView.FindControl("lblcat");
                    catvals[i] = catLabel.Text;
                }
                for(int i = 0 ; i < catvals.Length; i++)
                {
                    Response.Cookies["cat"+ i.ToString()].Value = catvals[i].ToString();
                }
