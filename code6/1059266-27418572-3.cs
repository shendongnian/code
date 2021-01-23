        using (DataClassesDataContext context = new DataClassesDataContext())
        {
            var id = (from obj in context.User_profiles
                      let num = context.User_profiles.Select(x => x.user_id).Cast<int>().Max()
                      select num).FirstOrDefault();
            _id.Text = "USR-" + id.ToString();
        }
