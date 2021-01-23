        using Microsoft.AspNet.Mvc;
        using Microsoft.AspNet.Diagnostics;
        using Microsoft.AspNet.Http.Features;
        // id = Http Status Error
        public IActionResult Error(String id)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var undhandledException = feature?.Error;
            var iisError = id;
            return View();
        }
