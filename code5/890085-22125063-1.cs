    @model IEnumerable<WebApplication6.Models.Article>
        <table width="100%">
          
            @foreach (var ct in Model)
            {
                i = i + 1;
                using (Ajax.BeginForm("DeleteArticle", "Home", new { Id = ct.Id }, new AjaxOptions()
             {
                 HttpMethod = "Post",
                 OnSuccess = "onSuccess",
                 UpdateTargetId = "mydiv"
             }, new { id = "Form" + i }))
                {
                    <tr>
                        <td style="padding-left:20px;">
                            @ct.ArticleContent
                    </td>
                    <td style="padding-left:20px;">
                        @ct.Id
                    </td>
                    <td>
                        <input type="submit" value="delete" id="delete_@i" />
                    </td>
                </tr>
                }
            }
        </table>
