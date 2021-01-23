    using (var db = new ABEntities())
    {
        var features = (from textObject in db.textObjects
                        join container in db.containers.DefaultIfEmpty() on textObject.textObjectPK equals container.textObjectPK into tObjsContainerJoined
                        from subContainerJoin in tObjsContainerJoined.DefaultIfEmpty()
                        join tObjsMedia in db.media on subContainerJoin.mediaID equals tObjsMedia.mediaID into tObjsMediaJoined
                        from subJoined in tObjsMediaJoined.DefaultIfEmpty()
                        from textContainer in tObjsContainerJoined
                        where textObject.version == Constants.Versions.LATEST &&
                                        textObject.textObjectTypeID == Constants.News.FEATURES && textObject.deployDate <= DateTime.Now
                        select new TextObject
                        {
                              Id = textObject.textObjectID,
                              Title = textObject.title,
                              ContainerId = textContainer.containerID,
                              Description = textContainer.container1,
                              DateCreated = textObject.deployDate,
                              Media = new Media
                                     {
                                           Title = subJoined.title,
                                           MediaFormat = subJoined.extension,
                                           MediaTypeID = subJoined.mediaTypeID,
                                           MediaFile = subJoined.fileName,
                                           Credit = subJoined.credit,
                                           MembersOnly = subJoined.membersOnly,
                                           LastModified = subJoined.lastModified,
                                           DateCreated = (DateTime?)subJoined.dateUploaded ?? DateTime.Now
                                      },
                               TypeId = textObject.textObjectTypeID
                       }).OrderByDescending(t => t.DateCreated).ToList();
    
       return features;
    }
