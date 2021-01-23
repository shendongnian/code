    using Newtonsoft.Json.Linq;
    JObject jsonObject =
         new JObject(
                 new JProperty("Date", DateTime.Now),
                 new JProperty("Album", "Me Against The World"),
                 new JProperty("Year", "James 2Pac-King's blog."),
                 new JProperty("Artist", "2Pac")
             )
