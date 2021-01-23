    catch (Exception ex)
                {
                    if (ex is AggregateException && ex.InnerException is Facebook.FacebookOAuthException && usedState != null && HttpContext.Current != null)
                    {
                        HttpContext.Current.Response.Redirect("~/FacebookLogin.aspx?logout=true");
                    }
                    else
                    {
                        throw;
                    }
                }
