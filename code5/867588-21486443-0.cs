            Regex reg = new Regex(@"(\[[^\]]+\])");
            string origString = "You can [xyz] blah blah [abc]";
            var coll = reg.Matches(origString);
            
            for(int i=0;i<coll.Count; i++)
            {
                origString = origString.Replace(coll[i].Value,"{"+i+"}");
            }
            var newString = string.Format(origString,".Net","desktop");
