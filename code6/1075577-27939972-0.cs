    @model string[,]
    <table>
    @for (int row = 0; row < Model.GetUpperBound(0); row++)
    {
        <tr>
        @for (int column = 0; column < Model.GetUpperBound(1); column++)
        {
            <td>@Model[row, column]</td>
        }
        </tr>
    }
    </table>
