    var foo = context.Contents.Include( "Content_Training" )
        .Where( c => c.ExpirationDate != null )
        .OrderBy( c => c.Content_Training.TrainingTypeId )
        .ThenBy( c => c.Name
        .Select( c => new { c.ContentId, c.Name, c.Content_Training.TrainingTypeId } );
