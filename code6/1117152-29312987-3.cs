    protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                courseListView.DataSource = GetCourses();
                courseListView.DataBind();
            }
            else
            {
                var result = string.Empty;
                var findCheckedQuery = courseListView
                    .Controls
                    .Cast<Control>()
                    .Select(x => (CheckBox)x.FindControl("chkBox"))
                    .Where(x => x.Checked)
                    .Select(x => x.Text);
                result = string.Join(", ", findCheckedQuery.ToArray());
            }
        }
