     foreach(StoryProgram sp in lstStoriestoClose)
            {
                try
                {
                    DateTime LastUpdateTimestamp;
                    DateTime CurrentTime = DateTime.Now;
                    LastUpdateTimestamp = sp.Story.LastUpdatedOn;
                    if ((CurrentTime - LastUpdateTimestamp).TotalHours > 24)
                    {
                        //Delete the story from database
                        //Check the gateway to delete the record in the db.
                        var storytoDelete= from story in stories
                                            where story.Id== sp.Story.Id
                                            select story;
                        
                       // stories.DeleteAllonSubmit(storytoDelete);
                        List<StoryProgram> lstStoriestoDelete = (from story in storytoDelete
                                                                join program in programs on story.ProgramId equals program.Id
                                                                join profile in Profiles on story.ProfileId equals profile.Id
                                                                select new StoryProgram(story, program, profile)).ToList();
                        foreach (StoryProgram sps in lstStoriestoDelete)
                        {
                            try
                            {
                                proxy.DeleteStoryItem(sps.Story.Id);
                            }
