                SessionContext resSession = new SessionContext();
                
                // I'm giving you example with standard bool property. You can put class property if you want.
                resSession.IsAdmin = Convert.ToInt32(userRow["IsAdmin"]) == 1;
                // this is Guid property for the User primary key, if you are using integer for primary key the property should be int.
                resSession.UserID = (Guid)userRow["ID"];
                BasicPage page = this.Page as BasicPage;
                page.UserSession = session;
                Response.Redirect("../Default.aspx");
