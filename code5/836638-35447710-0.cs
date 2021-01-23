    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using Microsoft.Practices.Unity;
    
    namespace Unity.Web
    {
        /// <summary>
        /// An <see cref="IHttpModule" /> that automatically injects dependencies into ASP.NET WebForms pages.
        /// </summary>
        /// <remarks>
        /// Since the pages have already been constructed by the time the module is called, constructor injection cannot be used. However,
        /// property injection can be used instead.
        /// </remarks>
        public class UnityHttpModule : IHttpModule
        {
            private HttpApplication _context;
            private bool _disposed;
    
            /// <summary>
            /// Initializes a module and prepares it to handle requests.
            /// </summary>
            /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
            public void Init(HttpApplication context)
            {
                _context = context;
                _context.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
            }
    
            /// <summary>
            /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
                Dispose(true);
            }
    
            /// <summary>
            /// Releases unmanaged and - optionally - managed resources.
            /// </summary>
            /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
            protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                if (_context != null)
                {
                    _context.PreRequestHandlerExecute -= OnPreRequestHandlerExecute;
                }
            }
            _disposed = true;
        }
        /// <summary>
        /// Handles the <see cref="E:PreRequestHandlerExecute" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnPreRequestHandlerExecute(object sender, EventArgs eventArgs)
        {
            var currentHandler = HttpContext.Current.Handler;
            if (currentHandler != null)
            {
                HttpContext.Current.Application.GetContainer().BuildUp(currentHandler.GetType(), currentHandler);
            }
            // User Controls are ready to be built up after page initialization is complete
            var currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
            {
                currentPage.InitComplete += OnPageInitComplete;
            }
        }
        /// <summary>
        /// Handles the <see cref="E:PageInitComplete" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnPageInitComplete(object sender, EventArgs e)
        {
            var currentPage = (Page)sender;
            var container = HttpContext.Current.Application.GetContainer();
            foreach (var c in GetControlTree(currentPage))
            {
                container.BuildUp(c.GetType(), c);
            }
        }
        /// <summary>
        /// Gets the controls in the page's control tree, excluding the page itself.
        /// </summary>
        /// <param name="root">The root control.</param>
        /// <returns>The child controls of the <paramref name="root" /> control.</returns>
        private static IEnumerable<Control> GetControlTree(Control root)
        {
            foreach (Control child in root.Controls)
            {
                yield return child;
                foreach (var control in GetControlTree(child))
                {
                    yield return control;
                }
            }
        }
    }
