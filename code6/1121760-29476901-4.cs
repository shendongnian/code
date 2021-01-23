    @{
        var listSize = 5;
        var numberOfLists = Model.Count/listSize;
        for (int listIndex = 0; listIndex < numberOfLists; listIndex++)
        {
            var list = Model.Skip(listIndex * listSize).Take(listSize);
               
            <div id="list@listIndex">
                <p>List @listIndex </p>
                @foreach(var element in list)
                {
                     <a href="@Url.Action("Details", "Table", new{ id = element.ElementID }, "")">
                     <img src="@element.ImagePath" /></a>
                }
            </div>
        }
    }
