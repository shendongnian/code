    <Extension>
    Public Function AddCustomValidationSummary(htmlHelper As HtmlHelper) As MvcHtmlString
        Dim result As String = String.Empty
        If (htmlHelper.ViewData.ModelState("") Is Nothing) AndAlso (htmlHelper.ViewData.ModelState("").Errors.Any()) Then
            result = "<div class='note note-danger'><h4 class='block'>Errors</h4><p>" & htmlHelper.ValidationSummary().ToString() & "</p></div>"
        End If
        Return New MvcHtmlString(result)
    End Function
