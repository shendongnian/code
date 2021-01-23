     private void functionToUpdateFields(some arguements)
     {
          /*Call Database and populate form fields*/
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         if (!isPostback)
         {
             functionToUpdateFields(some arguements);
         }
     }
     protected void Button1_Click(object sender, EventArgs e)
     {
            uservote.spAddLike(user.getId(), usermatch.getId());
            functionToUpdateFields(some arguements);
            VotePanel.Update();
     }
     protected void Button2_Click(object sender, EventArgs e)
     {
           uservote.spAddDislike(user.getId(), usermatch.getId());
           functionToUpdateFields(some arguements);
           VotePanel.Update();
     }
