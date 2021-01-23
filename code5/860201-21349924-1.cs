    public void UpdateSubTopics( int objectiveDetailId, IEnumerable<int> newSubTopicIds )
    {
        using( var db = new YourDbContext() )
        {
            // load SubTopics to add from DB
            var subTopicsToAdd = db.SubTopics
                .Where( st => newSubTopicIds.Contains( st.SubTopicId ) );
    
            // load target ObjectiveDetail from DB
            var targetObjDetail = db.ObjectiveDetail.Find( objectiveDetailId );
            // should check for targetObjDetail == null here
    
            // remove currently referenced SubTopics not found in subTopicsToAdd 
            foreach( var cst in targetObjDetail.SubTopics.Except( subTopicsToAdd ) )
            {
                cst.SubTopics.Remove( cst );
            }
    
            // add subTopicsToAdd not currently found in referenced SubTopics
            foreach( var nst in subTopicsToAdd.Except( targetObjDetail.SubTopics ) )
            {
                targetObjDetail.SubTopics.Add( nst );
            }
    
            // save changes
            db.SaveChanges();
        }
    }
