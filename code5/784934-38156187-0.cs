     ASPX:
    ===============
    <asp:DropDownList ID="GenreList" runat="server" SelectMethod="GenreList_GetData" DataTextField="Name" DataValueField="Id">
        </asp:DropDownList>
    
        C#:
        ============
         public IEnumerable<Genre> GenreList_GetData()
            {
                using(PlanetWroxEntities myEntities= new PlanetWroxEntities())
                {
                    return (from genre in myEntities.Genres
                            orderby genre.SortOrder
                            select genre).ToList();
                }
            }
