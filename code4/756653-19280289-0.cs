    /*You can try this, I've just shown the way of taking the value from the repeater, you     
     can modify it further for your need */
    protected void btnSave_Click(object sender, EventArgs e)
    {
     foreach (RepeaterItem item in questionRepeater.Items)
     {
     
      TextBox Qbox = item.FindControl("txtQ") as TextBox;
      TextBox Ansbox = item.FindControl("txtAns") as TextBox;
      string Question = Qbox.Text;
      string Answer =  Ansbox.Text;
       if (!string.IsNullOrEmpty(Answer))
       {
         //Peroform ur insert operation 
       }
     
    }
