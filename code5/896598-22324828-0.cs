       //just this will do 
        
       protected void btnAdd_Click(object sender, EventArgs e)
        {
          List <string > lst = (List<string >)Session["List"];          
          lst.Add(txtAdd.Text);
          // Change the list in session with new list
          Session["List"] = lst;
        }
