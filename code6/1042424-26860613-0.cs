    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"    Inherits="System.Web.Mvc.ViewPage<PagedList.IPagedList<ContosoUniversity.Models.Student>>" %>
    <%@ Import Namespace="PagedList.Mvc" %>
    <%:(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of Model.PageCount%>
    <%: Html.PagedListPager(Model, page => Url.Action("Index", 
    new { page, sortOrder = ViewBag.CurrentSort, currentFilter = ViewBag.CurrentFilter }))%>
