    public partial class Request
        {
	        public string ActualOrEmptyUserName 
	        {
	            get
	            {
	                var username = "";
                    if (Request.User != null && Request.User.Name != null)
                        username = Request.User.Name;
                    return username;
	            }
	        }
        }
    ...
    
    SDMs.Column("ActualOrEmptyUserName", "User")
