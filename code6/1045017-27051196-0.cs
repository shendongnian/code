        private void ModifyTrackInfo(string PathToWMA)
        {
            // "Last()" is an extension method on string defined elsewhere in project
            //      it simply get the to get the specified number of trailing characters of a string 
            string last2String = System.IO.Path.GetFileNameWithoutExtension(PathToWMA).Last(2);
            
            int last2Int;
            if (int.TryParse(last2String, out last2Int))
            {
                Tags.ASF.ASFTagInfo tagInfo = new Tags.ASF.ASFTagInfo(PathToWMA, true);                
                tagInfo.ContentDescription.Title =  string.Format("Track {0}", last2String);                
                tagInfo.Save();
            }            
        }
