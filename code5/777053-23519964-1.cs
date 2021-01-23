    @model IEnumerable<AppName.Models.ModelName>
    @{
       ViewBag.Title = "Home Page";
    }
    <form method="GET">
        <input type="search" name="searchTerm" />
        <input type="submit" value="Search for a name"/>
    </form>
    @try
    {
        foreach (var item in Model)
        {
            <h3>@Html.DisplayFor(modelItem => item.FirstName)</h3>
            <p>@Html.DisplayFor(modelItem => item.LastName)</p>
            
        }
    }
    catch (NullReferenceException nullex)
    {
        <p>@nullex</p>
    }
