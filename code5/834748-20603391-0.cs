    public void Configuration(IAppBuilder app)
            {
                app.Run(async context =>
                    {
                        //IF your request method is 'POST' you can use ReadFormAsync() over request to read the form 
                        //parameters
                        var formData = await context.Request.ReadFormAsync();
                        //Do the necessary operation here. 
                        await context.Response.WriteAsync("Hello");
                    });
            }
