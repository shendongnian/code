        public static List<string> GetContentControlsList(word.Document currentWordDocument)
        {
            List<string> contentControlsList = new List<string>();
            try
            {
                ContentControls contentControlsCollection = currentWordDocument.ContentControls;
                if (contentControlsCollection != null)
                {
                    if (contentControlsCollection.Count > 0)
                    {
                        foreach (ContentControl contentControl in contentControlsCollection)
                        {
                            if (!String.IsNullOrEmpty(contentControl.Title) && !contentControlsList.Contains(contentControl.Title))
                            {
                                contentControlsList.Add(contentControl.Title);
                            }
                        }
                    }
                }
                //Get storyRanges from document for header and footer properties
                StoryRanges storyRanges = currentWordDocument.StoryRanges;
                foreach (Range storyRange in storyRanges)
                {
                    ContentControls storyRangeControls = storyRange.ContentControls;
                    if (storyRangeControls != null)
                    {
                        if (storyRangeControls.Count > 0)
                        {
                            foreach (ContentControl control in storyRangeControls)
                            {
                                if (!String.IsNullOrEmpty(control.Title) && !contentControlsList.Contains(control.Title))
                                {
                                    contentControlsList.Add(control.Title);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO do error handling here
            }
            return contentControlsList;
        }
