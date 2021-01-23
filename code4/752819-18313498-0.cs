    protected void Button1_Click(object sender, EventArgs e)
            {
                Panel myDiv = new Panel(); //creating dynamic control
                myDiv.Attributes.Add("style", "display:block; width:100px; height:100px; background-color:red;"); //set attrs for visibility
                this.Page.Controls.Add(myDiv); // add to some control (now is Page)
            }
