    var data = from v in Jobs
               select new
               {
                  ID = v.Id,
                  Title = v.Title
               };
    
    position.DataSource = data.ToList();
    position.DataTextField = "Title";
    position.DataValueField = "ID";
    position.DataBind();
    position.Items.Insert(0, new ListItem("Applicant's position", ""));
