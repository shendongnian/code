    private void Addbtn_Click(object sender, EventArgs e){
    Recipe rc = new Recipe(Nametxt.Text);
    ListManager lm = new ListManager();
    lm.Add(rc);
    for (int index = 0; index < lm.Count; index++)
          {  
                Recipe recipe = lm.GetAt(index);
                ResultListlst.Items.Add(recipe.Name);
          }
    }
