    @model object
    <table>
        @{
            var properties = from prop in ViewData.ModelMetadata.Properties
                             let propInfo = prop.ContainerType.GetProperty(prop.PropertyName)
                             where !ViewData.TemplateInfo.Visited(prop)
                             select prop;
        }
        @foreach (var prop in properties)
        {
            <tr>
                <td>
                    <div style="float: right;">
                        @prop.GetDisplayName()
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        @Html.Editor(prop.PropertyName, new { ContainerModel = Model })
                    </div>
                </td>
            </tr>
        }
    </table>
