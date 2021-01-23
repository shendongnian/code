    protected void Datalist1_EditCommand(object source, DataListCommandEventArgs e)
            {
                if (e.CommandName.Equals("Edit"))
                {
                    session["id"]=yourid;
                    Response.Redirect("EditArtikull3.aspx");
                }
            }
