    private void postToWordpress(string title, string postContent,string tags, string aioTitle)
    {       
        string link = this.maskedTextBox1.Text;
        string username = this.maskedTextBox2.Text;
        string password = this.maskedTextBox3.Text;
    
        var wp = new WordPressWrapper(link + "/xmlrpc.php", username, password);
        var post = new Post();
    
        post.Title = title;
        post.Body = postContent;
        post.Tags = tags.Split(',');
    
        var cfs = new CustomField[] 
            { 
                new CustomField() 
                { 
                    // Don't pass in ID. It's auto assigned for new custom fields.
                    // ID = "name", 
                    Key = "aiosp_title", 
                    Value = "All in One SEO Title" 
                } 
            };
    
        post.CustomFields = cfs;
    
        wp.NewPost(post, false);
    }
