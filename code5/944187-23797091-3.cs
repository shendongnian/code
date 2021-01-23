    private void updateUserInformation()
    {
        int rowsAffected = 0;
      
        using(var dbContext = new DatabaseContext())
        {
            int userId = int.Parse(this.txtUserID.Text);
    
            // Load record to be updated - changes are tracked internally
            User userToUpdate = dbContext.Users.Find(userId);
    
            userToUpdate.First = this.txtFirst.Text.Trim();
            userToUpdate.Last = this.txtLast.Text.Trim();
            userToUpdate.Email = this.txtEmail.Text.Trim();
            userToUpdate.ModifiedAt = DateTime.Now;
    
            // Commit changes to DB
            rowsAffected = dbContext.SaveChanges();
        }
                
        if (rowsAffected > 0)
        {
            Response.Write("<script>alert('Row has been updated!');</script>");
            Response.Redirect("CreateAccount.aspx");
        }
    }
