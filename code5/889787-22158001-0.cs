    class JavaScriptResult : public IValueCallback {
        public void OnReceiveValue(Java.Lang.Object result) {
            Java.Lang.String json = (Java.Lang.String) result;
            // |json| is a string of JSON containing the result of your evaluation
        }
    }
