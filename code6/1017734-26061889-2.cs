    @model IDictionary<DateTime, List<Event>>
    @foreach(var item in Model)
    {
         //Display month name
         <h1>@item.Key.ToString("MMM", CultureInfo.InvariantCulture);</h1>
         foreach(var ev in item.Value)
         {
             //Row specific code
         }
    }
