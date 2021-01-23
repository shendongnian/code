     public static IObjectWithID FindById<T>(MongoCursor cursor, ObjectId id) where T: IObjectWithID
        {
            var query = Query<T>.Where(e => e.Id == id);
            var item = cursor.Collection.FindOneAs<T>(query);
    
            return item;
        }
