    <table>
        @{
            int numOfCols = 3; // You can change the number of columns here
            int numOfRows = Math.Ceiling(Model.Amenities.Count / numOfCols);
        }
        @for (int row = 0; row < numOfRows; row++)
        {
            <tr>
                for (int col = 0; col < numOfCols; col++)
                {
                    var amenity = Model.Amenities[row * numOfCols + col];
                    <td>@amenity.Description</td>
                }
            </tr>
        }
    </table>
