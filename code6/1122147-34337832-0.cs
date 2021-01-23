    <table>
            <thead>
                    <tr>
                         <td><b>My List Data:</b></td>
                    </tr>
            </thead>
            <tbody>
                    @{
                       var items = Model.MyList;
                       const int colCount = 2;
                    }
                    @for (var i = 0; i < items.Count(); i += colCount)
                    {
                      <tr>
                            @for (var c = 0; c < colCount && i + c < items.Count(); c++)
                            {
                                <td>@(items[i + c].Display):</td>
                            }
                      </tr>
                    }
            </tbody>
    </table>
