    namespace Project.UserControls
    {
        public class PostControl : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack)
                {
                    PostValidator validator = new PostValidator();
                    Post entity = new Post()
                    {
                        // Map form fields to entity properties
                        Id = Convert.ToInt32(PostId.Value),
                        Title = PostTitle.Text.Trim(),
                        Body = PostBody.Text.Trim()
                    };
                    ValidationResult results = validator.Validate(entity);
                    if (results.IsValid)
                    {
                        // Save to the database and continue to the next page
                    }
                    else
                    {
                        BulletedList summary = (BulletedList)FindControl("ErrorSummary");
                        // Display errors to the user
                        foreach (var failure in results.Errors)
                        {
                            Label errorMessage = FindControl(failure.PropertyName + "Error") as Label;
                            if (errorMessage == null)
                            {
                                summary.Items.Add(new ListItem(failure.ErrorMessage));
                            }
                            else
                            {
                                errorMessage.Text = failure.ErrorMessage;
                            }
                        }
                    }
                }
                else
                {
                    // Display form
                }
            }
            ...
        }
    }
