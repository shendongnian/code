        using (DataClassesDataContext context = new DataClassesDataContext())
        {
            int id = context.User_profiles.Select(x => 
                     {
                        int result;
                        int.TryParse(Convert.ToString(x.user_id), out result);
                        return result;
                     }).Max();
            _id.Text = "USR-" + id;
        }
