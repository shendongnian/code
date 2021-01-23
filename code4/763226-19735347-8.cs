    @using System.Web.Http
    @using System.Web.Http.Description
    @using MvcApplication2.Areas.HelpPage.Models
    @model IDictionary<string, TypeDocumentation>
    @foreach (var modelType in Model)
    {
        <h3>@modelType.Key</h3>
        if (modelType.Value.Summary != null)
        {
        <p>@modelType.Value.Summary</p>
        }
        <table class="help-page-table">
            <thead>
                <tr>
                    <th>Property</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var propInfo in modelType.Value.PropertyDocumentation)
                {
                    <tr>
                        <td class="parameter-name"><b>@propInfo.Name</b> (@propInfo.Type)</td>
                    
                        <td class="parameter-documentation">
                            <pre>@propInfo.Documentation</pre>
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    }
