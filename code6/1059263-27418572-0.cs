        using (DataClassesDataContext context = new DataClassesDataContext())
        {
            int id = context.User_profiles.Select(x => Convert.ToInt32(x.user_id)).Max();
            _id.Text = "USR-" + id;
        }
