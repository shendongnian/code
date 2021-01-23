    ShapeEntity resolvedEntity = null;
    string shapeType = props["ShapeType"].StringValue;
    if (shapeType == "Rectangle") { resolvedEntity = new RectangleEntity(); }
    else if (shapeType == "Ellipse") { resolvedEntity = new EllipseEntity(); }
    else if (shapeType == "Line") { resolvedEntity = new LineEntity(); }    
    // Potentially throw here if an unknown shape is detected 
    resolvedEntity.PartitionKey = pk;
    resolvedEntity.RowKey = rk;
    resolvedEntity.Timestamp = ts;
    resolvedEntity.ETag = etag;
    resolvedEntity.ReadEntity(props, null);
    return resolvedEntity;
};
    currentSegment = await drawingTable.ExecuteQuerySegmentedAsync(drawingQuery, shapeResolver, currentSegment != null ? currentSegment.ContinuationToken : null);
