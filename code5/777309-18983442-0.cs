            pipelines.BeforeRequest.AddItemToStartOfPipeline(
            context =>
            {
                var route = routeResolver.Resolve(context);
                if (route == null || route.Route == null || route.Route.Description == null) // probably not necessary but don't want the chance of losing visibility on anything
                {
                    NewRelicAgent.SetTransactionName(
                        context.Request.Method,
                        context.Request.Url.ToString());
                }
                else
                {
                    NewRelicAgent.SetTransactionName(
                        route.Route.Description.Method,
                        route.Route.Description.Path);
                }
                return null;
            });
