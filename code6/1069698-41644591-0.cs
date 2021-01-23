    for (var i = 0; i < wordDoc.InlineShapes.Count; i++) {
        if (wordDoc.InlineShapes[i].LinkFormat == null) {
            continue;
        }
    
        wordDoc.InlineShapes[i].LinkFormat.SavePictureWithDocument = true;
    }
