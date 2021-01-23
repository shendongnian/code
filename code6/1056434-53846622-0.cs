    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMvc();
        //your code below
        app.Run(async (context) =>
        {
            string body;
            using (Stream receiveStream = context.Request.Body)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    body = readStream.ReadToEnd();
                }
            }
            Console.WriteLine(body.ToString());
        });
       
    }
