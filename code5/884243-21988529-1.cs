    .Columns(c =>
        {
            c.Bound(i => i.ReferralDate).Title("Date");
              c.Bound(i=>i.User).EditorTemplateName("UserListEditor")
              .ClientTemplate("#=User.UserName#");
         }
            
    c.Command(cmd => {
                cmd.Edit();
                cmd.Destroy();
            });
    
        })
