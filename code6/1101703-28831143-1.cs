    public class MyModule : IHttpModule {
        public void Init(HttpApplication context) {
            context.Error += OnRequestError;
        }
        private void OnRequestError(object sender, EventArgs e) {
            var context = ((HttpApplication)sender).Context;
            var error = context.Error;
            if (error == null)
                return;
            var errorType = error.GetType();
            if (errorType == typeof(HttpException))
                // do something
            // this is what you are looking for
            if (errorType = typeof(HttpRequestValidationException))
                // do something, whatever you want
            // works for me, so should work to you too
        }
    }
