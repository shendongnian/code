    @model List<string>
    @{
        var listSize = 5;
        for (int i = 0; i < Model.Count/listSize; i++)
        {
            var list = Model.Skip(i*listSize).Take(listSize);
               
            <div id="list@i">
                <p>List @i </p>
                @foreach(var element in list)
                {
                     <p> @Html.DisplayFor(m => element) </p>
                }
            </div>
        }
    }
