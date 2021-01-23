                var facebookAuthenticationOptions = new FacebookAuthenticationOptions() {
                AppId = "1481969698749084",
                AppSecret = "43dbeb12c161377448d5c67e3a6a42e7",
                AuthenticationType = "Facebook",
                SignInAsAuthenticationType = "ExternalCookie",
                Provider = new FacebookAuthenticationProvider {
                    OnAuthenticated = async ctx => {
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.Country, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.Gender, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.MobilePhone, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.OtherPhone, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.HomePhone, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.StateOrProvince, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.Email, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.Country, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.Actor, ctx.User["birthday"].ToString()));
                        ctx.Identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, ctx.User["birthday"].ToString()));
                    }
                }
            };
            facebookAuthenticationOptions.Scope.Add("user_birthday");
            //facebookAuthenticationOptions.Scope.Add("first_name");
            //facebookAuthenticationOptions.Scope.Add("last_name");
            facebookAuthenticationOptions.Scope.Add("publish_stream");
            facebookAuthenticationOptions.Scope.Add("user_likes");
            facebookAuthenticationOptions.Scope.Add("friends_likes");
            facebookAuthenticationOptions.Scope.Add("user_about_me");
            facebookAuthenticationOptions.Scope.Add("user_friends");
            facebookAuthenticationOptions.Scope.Add("user_actions.news");
            facebookAuthenticationOptions.Scope.Add("user_actions.video");
            facebookAuthenticationOptions.Scope.Add("user_education_history");
            facebookAuthenticationOptions.Scope.Add("manage_pages");
            facebookAuthenticationOptions.Scope.Add("user_interests");
            facebookAuthenticationOptions.Scope.Add("user_location");
            facebookAuthenticationOptions.Scope.Add("user_photos");
            facebookAuthenticationOptions.Scope.Add("user_relationships");
            facebookAuthenticationOptions.Scope.Add("user_relationship_details");
            facebookAuthenticationOptions.Scope.Add("user_status");
            facebookAuthenticationOptions.Scope.Add("user_tagged_places");
            facebookAuthenticationOptions.Scope.Add("user_videos");
            facebookAuthenticationOptions.Scope.Add("user_website");
            facebookAuthenticationOptions.Scope.Add("read_friendlists");
            facebookAuthenticationOptions.Scope.Add("read_stream");
            facebookAuthenticationOptions.Scope.Add("email");
            app.UseFacebookAuthentication(facebookAuthenticationOptions);
