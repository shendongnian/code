    var activities = from activity in ParseObject.GetQuery("Activity")
                                 where activity.Get<string>("type") == "follow"
                                 && activity["fromUser"] == ParseObject.CreateWithoutData<ParseUser>(id)
                                 select activity;
                var stories = from story in ParseObject.GetQuery("Story")
                               join activity in activities on story["createdBy"] equals activity["toUser"]
                               select story;
                var userstories = from story in ParseObject.GetQuery("Story")
                                  where story["createdBy"] == ParseObject.CreateWithoutData<ParseUser>(id)
                                  select story;
                ParseQuery<ParseObject> query = stories.Or(userstories).Skip(skip).Limit(limit).Include("createdBy")
                    .OrderBy("-createdAt");
                var results = await query.FindAsync();
