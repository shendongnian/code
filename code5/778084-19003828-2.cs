    var Result = (from s in context.301Redirects
                  where s.IsDeleted == false && s.Status == true)
                 .ToList()
                 .FirstOrDefault(HttpUtility.UrlDecode(s.OldURL).ToUpper() == HttpUtility.UrlDecode(OldURLPath).ToUpper();
                return Result;
