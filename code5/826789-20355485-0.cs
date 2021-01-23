    var query = blah.Select(b => new abc{
                            No = VKNT,
                            GuidID=hdnGuidID.Value.ToString(),
                            RecID=hdnRecID.Value.ToString(),
                            Date=HdnDate.Value.ToString()                    
                            })
                     .OrderBy(l => l.Date)
                     .GroupBy(l => l.No)
                     .ToList();
