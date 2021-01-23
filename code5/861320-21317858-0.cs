        if (linkList.Count == 1)
        {
	var firstItem = linkList[0];
           p2Trace.FileName = firstItem.FileName;
           p2Trace.Title = firstItem.Title;
           p2Trace.HotspotID= firstItem.HostspotID;
           jumpTo(p2Trace.FileName, p2Trace.Titel, p2Trace.HotspotID);
        }
