    private void button7_Click(object sender, EventArgs e)
            {  
                var responsePost = "";
                try
                {
                    var objFacebookClient = new FacebookClient(AccessPageToken);
                    objFacebookClient.Delete("344087212396598_344775698994416").ToString();
                }
                catch (Exception ex)
                {
                    responsePost = "Facebook Posting Error Message: " + ex.Message;
                }
            }
