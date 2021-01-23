    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            .....
            // Attribute routing (with inheritance).
            config.MapHttpAttributeRoutes(new WebApiCustomDirectRouteProvider());
            ....
        }
    }
