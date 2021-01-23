    if (Regex.IsMatch(txtSearch.Text, "[^a-zA-Z0-9 %]"))
                {
                    //error
                    Response.Redirect("Error.aspx?tx=It's a Shame Dude!");
                }
                else
                {
                    //Remove multiple spaces
                    String ClearSpaces = Regex.Replace(txtSearch.Text, @"\s+", " ");
                    Response.Redirect("search?tx=" + HttpUtility.UrlEncode(ClearSpaces));
                }
