    <table>
            for (int z = 0; z < Model.reportContentsCharts.Count; z += 2)
            {                     
                <tr>
                    for (int c = z; c < z + 2; c++)
                    {
                        <td align="center">                             
                            if (c < Model.reportContentsCharts.Count)
                            {
                                <img src="@Model.GetChart(Model.reportContentsCharts[c])"/>
                            }
                        </td>
                    }
                </tr>                       
            }
    </table>
