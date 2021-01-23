    Protected void btnbatch_Click(object sender, EventArgs e)
    {
       
        Button btnactual= sender as Button;
        ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
        foreach (Control ctrl in myContent.FindControl("divBatches").Controls)
        {
            if (ctrl.ID == btnactual.ID)
            {
               //blah blah
            }
         }
      }
