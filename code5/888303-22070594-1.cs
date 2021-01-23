    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
    <%
    	ViewDataDictionary attributes = ViewData;
    	attributes.Add("class", "def-text-input datetime-input");
    %>
    <%= Html.TextBox(string.Empty, string.Format("{0:d-M-yyyy}", Model), attributes) %>
