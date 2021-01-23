    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<namespace.ViewModel>" %>
    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
            <%: Html.HiddenFor(model => model.ID) %>
            <div class="editor-field">
                <%: Html.DropDownList("TableObject", IEnumerable<SelectListItem>)ViewBag.EditTable,String.Empty)%>
            </div>
    <% } %>
