    <table>
        @{
            int numOfCols = 3; // You can change the number of columns here
            int numOfRows = Math.Ceiling(Model.Amenities.Count / numOfCols);
            // or if you don't want to use Math.Ceiling...
            // int numOfRows = Model.Amenities.Count / numOfCols;
            // if (Model.Amenities.Count % numOfCols != 0)
            //     numOfRows++;
        }
        @for (int row = 0; row < numOfRows; row++)
        {
            <tr>
                for (int col = 0; col < numOfCols; col++)
                {
                    int index = row * numOfCols + col;
                    if(index < Model.Amenities.Count)
                    {
                        var amenity = Model.Amenities[index];
                        <td>@amenity.Description</td>
                    }
                    else
                    {
                        <td>&nbsp;</td>
                    }
                }
            </tr>
        }
    </table>
