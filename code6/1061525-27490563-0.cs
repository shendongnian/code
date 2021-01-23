    using (Property_dbDataContext context = new Property_dbDataContext())
            {
                var user = (from a in context.User_profiles
                            where a.user_id == Convert.ToInt32(Request.QueryString["user_id"])
                            select a).FirstOrDefault();
    
    
                user.email = _Email.Text;
                user.first_name = _FirstName.Text;
                user.last_name = _LastName.Text;
                user.phone = _Phone.Text;
                user.cell = _Cell.Text;
                user.fax = _Fax.Text;
                user.address = _Address.Text;
                user.zip_code = _ZipCode.Text;
                user.country = _Country.SelectedItem.Text;
                
                context.User_profiles.Attach(user);
                context.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
                context.SubmitChanges();
             }
