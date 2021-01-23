    @{
       // Get the session timeout from configuration
       var sessionTimeout = (System.Web.Configuration.ConfigurationManager.GetSection("system.web/sessionState") as System.Web.Configuration.SessionStateSection).Timeout;
       // Ping interval can just a minute less that the session expiry
       var pingInterval = sessionTimeout.AddMinutes(-1.0);
    }
    <script type="text/javascript">
       window.setInterval(function () {
         $.ajax('@Url.Content("~")', { async: true, cache: false });
       }, @((int)pingInterval.TotalMilliseconds));
    </script>
